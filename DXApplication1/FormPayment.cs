using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DXApplication1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPayment : XtraForm
    {
        public string PaymentHeaderID = Guid.NewGuid().ToString();
        public string InvoiceHeaderID { get; set; }
        public int PaymentType { get; set; }
        public decimal SummaryNetAmount { get; set; }

        SqlMethods sqlMethods = new SqlMethods();

        public FormPayment(int PaymentType, decimal SummaryNetAmount, string InvoiceHeaderID)
        {
            InitializeComponent();
            AcceptButton = simpleButtonOk;
            CancelButton = simpleButtonCancel;
            this.PaymentType = PaymentType;
            this.SummaryNetAmount = SummaryNetAmount;
            this.InvoiceHeaderID = InvoiceHeaderID;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            switch (PaymentType)
            {
                case 1:
                    textEditCash.EditValue = SummaryNetAmount;
                    break;
                case 2:
                    textEditCashless.EditValue = SummaryNetAmount;
                    break;
                case 3:
                    textEditBonus.EditValue = SummaryNetAmount;
                    break;
                default:
                    break;
            }
        }


        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            textEditCash.DoValidate();
        }

        private void textEditCash_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val < 0)
                e.Cancel = true;
        }

        private void textEditCash_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 dan az olmamalıdır";
        }

        private void simpleButtonUpdateCash_Click(object sender, EventArgs e)
        {
            decimal restAmount = SummaryNetAmount - (Convert.ToDecimal(textEditCashless.EditValue) + Convert.ToDecimal(textEditBonus.EditValue));
            if (restAmount >= 0)
                textEditCash.EditValue = restAmount;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            textEditCashless.DoValidate();
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val < 0)
                e.Cancel = true;
            else if (val > SummaryNetAmount)
                e.Cancel = true;

        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən " + SummaryNetAmount + "dan çox olmamalıdır";
        }
        private void simpleButtonUpdateCashless_Click(object sender, EventArgs e)
        {
            decimal restAmount = SummaryNetAmount - (Convert.ToDecimal(textEditCash.EditValue) + Convert.ToDecimal(textEditBonus.EditValue));
            if (restAmount >= 0)
                textEditCashless.EditValue = restAmount;
        }

        private void simpleButtonNum_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            decimal cashLarge = Convert.ToDecimal(textEditCash.EditValue);
            decimal cashless = Convert.ToDecimal(textEditCashless.EditValue);
            decimal bonus = Convert.ToDecimal(textEditBonus.EditValue);
            string NewDocNum = sqlMethods.GetNextDocNum("P", "DocumentNumber", "trPaymentHeader");

            if ((cashLarge + cashless + bonus) >= SummaryNetAmount)
            {
                decimal cash = SummaryNetAmount - Convert.ToDecimal(textEditCashless.EditValue) - Convert.ToDecimal(textEditBonus.EditValue);
                if (!sqlMethods.PaymentHeaderExist(InvoiceHeaderID))
                {
                    trPaymentHeader trPayment = new trPaymentHeader()
                    {
                        PaymentHeaderID = PaymentHeaderID,
                        DocumentNumber = NewDocNum,
                        InvoiceHeaderID = InvoiceHeaderID
                    };
                    int result = sqlMethods.InsertPaymentHeader(trPayment);

                    if (cash > 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = cash,
                            PaymentTypeCode = 1
                        };
                        int result2 = sqlMethods.InsertPaymentLine(trPaymentLine);
                    }

                    if (cashless > 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = cashless,
                            PaymentTypeCode = 2
                        };
                        int result2 = sqlMethods.InsertPaymentLine(trPaymentLine);

                    }

                    if (bonus > 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = bonus,
                            PaymentTypeCode = 3
                        };
                        int result2 = sqlMethods.InsertPaymentLine(trPaymentLine);
                    }
                }

                decimal change = Convert.ToDecimal(textEditCash.EditValue) + Convert.ToDecimal(textEditCashless.EditValue) + Convert.ToDecimal(textEditBonus.EditValue) - SummaryNetAmount;
                if (change > 0)
                {
                    using (FormChange formChange = new FormChange(cashLarge, change))
                    {
                        formChange.ShowDialog(this);
                    }
                }
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Ödəmə ödənilməli olan məbləğdən azdır");
        }
    }
}