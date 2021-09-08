using DevExpress.XtraEditors;
using System;
using DXApplication1.Model;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class UcReturn : XtraUserControl
    {
        public string returnInvoiceHeaderID;
        public object invoiceHeaderID;
        public object invoiceLineID;
        public decimal returnNetAmount;
        SqlMethods sqlMethods = new SqlMethods();
        public UcReturn()
        {
            InitializeComponent();
        }

        private void UcReturn_VisibleChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = sqlMethods.SelectInvoiceHeader();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            invoiceHeaderID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceHeaderID");
            invoiceLineID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "invoiceLineID");
            returnInvoiceHeaderID = Guid.NewGuid().ToString();
            gridControl2.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderID.ToString());
            gridControl3.DataSource = sqlMethods.SelectPaymentLine(invoiceHeaderID.ToString());
        }

        private void repoButtonReturnLine_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                object invoiceLineID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "InvoiceLineId");
                int maxReturn = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "RemainingQty"));

                if (maxReturn > 0)
                {
                    using (FormQty formQty = new FormQty(maxReturn))
                    {
                        if (formQty.ShowDialog(this) == DialogResult.OK)
                        {
                            if (!sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderID)) //if invoiceHeader doesnt exist
                            {
                                string NewDocNum = sqlMethods.GetNextDocNum("RS", "DocumentNumber", "trInvoiceHeader");
                                trInvoiceHeader trInvoiceHeader = new trInvoiceHeader()
                                {
                                    InvoiceHeaderID = returnInvoiceHeaderID,
                                    DocumentNumber = NewDocNum,
                                    IsReturn = true
                                };
                                sqlMethods.InsertInvoiceHeader(trInvoiceHeader);
                            }

                            if (!sqlMethods.InvoiceLineExist(returnInvoiceHeaderID, invoiceLineID))
                            {
                                trInvoiceLine trInvoiceLine = new trInvoiceLine()
                                {
                                    InvoiceLineId = Guid.NewGuid().ToString(),
                                    InvoiceHeaderID = returnInvoiceHeaderID,
                                    RelatedLineId = invoiceLineID.ToString(),
                                    Qty = (formQty.qty * (-1))
                                };
                                sqlMethods.InsertInvoiceLine(trInvoiceLine);
                            }
                            else
                                sqlMethods.UpdateInvoiceLineQty(returnInvoiceHeaderID, invoiceLineID, formQty.qty * (-1));

                            gridControl2.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderID.ToString());
                            returnNetAmount = Convert.ToDecimal(sqlMethods.SelectInvoiceLine(returnInvoiceHeaderID).Compute("Sum(NetAmount)", string.Empty));
                            MessageBox.Show(returnNetAmount.ToString());

                        }
                    }
                }
                else
                    MessageBox.Show("Geri qaytarıla bilecek miqdar yoxdur");
            }
        }

        private void simpleButtonPayment_Click(object sender, EventArgs e)
        {
            decimal summaryNetAmount = Convert.ToDecimal(gridView1.Columns["NetAmount"].SummaryItem.SummaryValue);

            if (summaryNetAmount > 0)
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

                using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, invoiceHeaderID.ToString()))
                {
                    if (formPayment.ShowDialog(this) == DialogResult.OK)
                    {
                        sqlMethods.UpdateInvoiceIsCompleted(invoiceHeaderID.ToString());

                        invoiceHeaderID = Guid.NewGuid().ToString();

                        gridControl2.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderID.ToString());
                    }
                }
            }
            else MessageBox.Show("Ödəmə 0a bərabərdir");
        }
    }
}
