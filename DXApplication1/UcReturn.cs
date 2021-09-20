using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using System.Data;

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

        private void UcReturn_VisibleChanged(object sender, EventArgs e)
        {
            gridControlInvoiceHeader.DataSource = sqlMethods.SelectInvoiceHeader();
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            invoiceHeaderId = (Guid)gridViewInvoiceHeader.GetRowCellValue(gridViewInvoiceHeader.FocusedRowHandle, "InvoiceHeaderId");
            invoiceLineID = (Guid)gridViewInvoiceHeader.GetRowCellValue(gridViewInvoiceHeader.FocusedRowHandle, "invoiceLineID");
            returnInvoiceHeaderId = Guid.NewGuid();
            gridControlInvoiceLine.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
            gridControlPaymentLine.DataSource = sqlMethods.SelectPaymentLine(invoiceHeaderId);
        }

        private void repoButtonReturnLine_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                object invoiceLineID = gridViewInvoiceLine.GetRowCellValue(gridViewInvoiceLine.FocusedRowHandle, "InvoiceLineId");
                int maxReturn = Convert.ToInt32(gridViewInvoiceLine.GetRowCellValue(gridViewInvoiceLine.FocusedRowHandle, "RemainingQty"));

                if (maxReturn > 0)
                {
                    using (FormQty formQty = new FormQty(maxReturn))
                    {
                        if (formQty.ShowDialog(this) == DialogResult.OK)
                        {
                            if (!sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderId)) //if invoiceHeader doesnt exist
                            {
                                string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");
                                trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                                {
                                    InvoiceHeaderId = returnInvoiceHeaderId,
                                    DocumentNumber = NewDocNum,
                                    ProcessCode = "RS",
                                    IsReturn = true
                                };
                                sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
                            }

                            if (!sqlMethods.InvoiceLineExist(returnInvoiceHeaderId, invoiceLineID))
                            {
                                trInvoiceLine trInvoiceLine = new trInvoiceLine()
                                {
                                    InvoiceLineId = Guid.NewGuid(),
                                    InvoiceHeaderId = returnInvoiceHeaderId,
                                    RelatedLineId = (Guid)invoiceLineID,
                                    Qty = (formQty.qty * (-1))
                                };
                                sqlMethods.InsertInvoiceLine(trInvoiceLine);
                            }
                            else
                                sqlMethods.UpdateInvoiceLineQty(returnInvoiceHeaderId, invoiceLineID, formQty.qty * (-1));

                            gridControlInvoiceLine.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderId);
                        }
                    }
                }
                else
                    MessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");
            }
        }

        private void simpleButtonPayment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(sqlMethods.SelectInvoiceLine(returnInvoiceHeaderId).Compute("Sum(NetAmount)", string.Empty));

            if (summaryNetAmount < 0)
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
                    }
                }
            }
            else MessageBox.Show("Ödəmə 0a bərabərdir");
        }
    }
}
