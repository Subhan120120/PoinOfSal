using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class UcReturn : XtraUserControl
    {
        public Guid returnInvoiceHeaderId;
        public Guid invoiceHeaderId;
        public Guid invoiceLineID;
        SqlMethods sqlMethods = new SqlMethods();

        public UcReturn()
        {
            InitializeComponent();
        }

        private void UcReturn_Load(object sender, EventArgs e)
        {
            this.ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing); // set Parent Form Closing event
        }

        void ParentForm_FormClosing(object sender, FormClosingEventArgs e) // Parent Form Closing event
        {
            if (sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                sqlMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete incomplete invoice
        }

        private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormInvoiceHeaderList formInvoiceHeaderList = new FormInvoiceHeaderList())
            {
                if (formInvoiceHeaderList.ShowDialog(this) == DialogResult.OK)
                {
                    btnEdit_InvoiceHeader.EditValue = formInvoiceHeaderList.TrInvoiceHeader.DocumentNumber;
                    invoiceHeaderId = formInvoiceHeaderList.TrInvoiceHeader.InvoiceHeaderId;

                    if (sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderId))
                        sqlMethods.DeleteInvoice(returnInvoiceHeaderId);                // delete previous invoice
                    returnInvoiceHeaderId = Guid.NewGuid();                             // create next invoice

                    DataTable trInvoiceLine = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                    gC_InvoiceLine.DataSource = trInvoiceLine;

                    gC_PaymentLine.DataSource = sqlMethods.SelectPaymentLines(invoiceHeaderId);
                    gC_ReturnInvoiceLine.DataSource = null;
                }
            }
        }

        private void repobtn_ReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);

            if (buttonIndex == 0)
            {
                Guid invoiceLineID = (Guid)gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "InvoiceLineId");
                int maxReturn = Convert.ToInt32(gV_InvoiceLine.GetRowCellValue(gV_InvoiceLine.FocusedRowHandle, "RemainingQty"));

                if (maxReturn > 0)
                {
                    using (FormQty formQty = new FormQty(maxReturn))
                    {
                        if (formQty.ShowDialog(this) == DialogResult.OK)
                        {
                            if (!sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                            {
                                string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "TrInvoiceHeaders");
                                TrInvoiceHeader TrInvoiceHeader = new TrInvoiceHeader()
                                {
                                    InvoiceHeaderId = returnInvoiceHeaderId,
                                    DocumentNumber = NewDocNum,
                                    ProcessCode = "RS",
                                    IsReturn = true
                                };
                                sqlMethods.InsertInvoiceHeader(TrInvoiceHeader);
                            }

                            if (!sqlMethods.InvoiceLineExist(returnInvoiceHeaderId, invoiceLineID))
                            {
                                TrInvoiceLine invoiceLine = sqlMethods.SelectInvoiceLine(invoiceLineID);

                                TrInvoiceLine returnInvoiceLine = new TrInvoiceLine
                                {
                                    InvoiceLineId = Guid.NewGuid(),
                                    InvoiceHeaderId = returnInvoiceHeaderId,
                                    RelatedLineId = invoiceLineID,
                                    ProductCode = invoiceLine.ProductCode,
                                    Qty = formQty.qty * (-1),
                                    Price = invoiceLine.Price,
                                    Amount = Convert.ToDecimal(formQty.qty * invoiceLine.Price * (-1)),
                                    PosDiscount = formQty.qty * invoiceLine.PosDiscount / invoiceLine.Qty * (-1),
                                    NetAmount = formQty.qty * invoiceLine.NetAmount / invoiceLine.Qty * (-1), 
                                };

                                sqlMethods.InsertInvoiceLine(returnInvoiceLine);

                                gC_ReturnInvoiceLine.DataSource = sqlMethods.SelectInvoiceLines(returnInvoiceHeaderId);
                            }
                            else
                                sqlMethods.UpdateInvoiceLineQty(returnInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                            gC_InvoiceLine.DataSource = sqlMethods.SelectInvoiceLines(invoiceHeaderId);
                        }
                    }
                }
                else
                    XtraMessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");
            }
        }

        private void btn_Payment_Click(object sender, EventArgs e)
        {
            object sumNetAmount = sqlMethods.SelectInvoiceLines(returnInvoiceHeaderId).Compute("Sum(NetAmount)", string.Empty);
            decimal summaryNetAmount = Convert.ToDecimal(sumNetAmount == DBNull.Value ? 0 : sumNetAmount); 

            if (summaryNetAmount != 0)
            {
                int paymentType = 0;

                SimpleButton simpleButton = sender as SimpleButton;
                switch (simpleButton.Name)
                {
                    case "simpleButtonCash":
                        paymentType = 1;
                        break;
                    case "simpleButtonCashless":
                        paymentType = 2;
                        break;
                    case "simpleButtonCustomerBonus":
                        paymentType = 3;
                        break;
                    default:
                        break;
                }

                using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, returnInvoiceHeaderId))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        returnInvoiceHeaderId = Guid.NewGuid();
                        sqlMethods.UpdateInvoiceIsCompleted(invoiceHeaderId);

                        gC_InvoiceLine.DataSource = null;
                        gC_PaymentLine.DataSource = null;
                        gC_ReturnInvoiceLine.DataSource = null;
                        btnEdit_InvoiceHeader.EditValue = null;
                    }
                }
            }
            else XtraMessageBox.Show("Ödəmə 0a bərabərdir");
        }

        private void gV_ReturnInvoiceLine_CalcPreviewText(object sender, CalcPreviewTextEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            //string Barcode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Barcode"]);
            decimal PosDiscount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["PosDiscount"]));
            decimal Amount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["Amount"]));
            decimal NetAmount = Convert.ToDecimal(view.GetRowCellDisplayText(e.RowHandle, view.Columns["NetAmount"]));
            string SalesPersonCode = view.GetRowCellDisplayText(e.RowHandle, view.Columns["SalesPersonCode"]);
            string strVatRate = view.GetRowCellDisplayText(e.RowHandle, view.Columns["VatRate"]);
            float VatRate = float.Parse(strVatRate);

            e.PreviewText = Methods.GetPreviewText(PosDiscount, Amount, NetAmount, VatRate, String.Empty, SalesPersonCode);
        }
    }
}
