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
        SqlMethods sqlMethods = new SqlMethods();
        public UcReturn()
        {
            InitializeComponent();
        }

        private void UcReturn_Load(object sender, EventArgs e)
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

        private void repoItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            int buttonIndex = editor.Properties.Buttons.IndexOf(e.Button);
            if (buttonIndex == 0)
            {
                object invoiceLineID = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "InvoiceLineId");
                if (!sqlMethods.InvoiceHeaderExist(returnInvoiceHeaderID)) //if invoiceHeader doesnt exist
                {
                    string NewDocNum = sqlMethods.GetNextDocNum("RS","DocumentNumber", "trInvoiceHeader");
                    sqlMethods.InsertInvoiceHeader(returnInvoiceHeaderID, NewDocNum);
                }

                trInvoiceLine trInvoiceLine = new trInvoiceLine() {
                    InvoiceLineId = Guid.NewGuid().ToString(),
                    InvoiceHeaderID = returnInvoiceHeaderID,
                    RelatedLineId = invoiceLineID.ToString()
                };
                int result = sqlMethods.InsertInvoiceLine(trInvoiceLine);

                if (result > 0)
                {
                    gridControl2.DataSource = sqlMethods.SelectInvoiceLine(returnInvoiceHeaderID);
                    gridView2.MoveLast();
                }
                else
                    MessageBox.Show("Məhsul əlavə edilə bilmədi");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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

                //using (FormPayment formPayment = new FormPayment(paymentType, summaryNetAmount, invoiceHeaderID))
                //{
                //    if (formPayment.ShowDialog(this) == DialogResult.OK)
                //    {
                //        sqlMethods.UpdateIsCompleted(invoiceHeaderID);

                //        invoiceHeaderID = Guid.NewGuid().ToString();

                //        gridControl2.DataSource = sqlMethods.SelectInvoiceLine(invoiceHeaderID);                        
                //    }
                //}
            }
            else MessageBox.Show("Ödəmə 0a bərabərdir");
        }
    }
}
