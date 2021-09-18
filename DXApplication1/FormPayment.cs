using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DXApplication1.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPayment : XtraForm
    {
        public string PaymentHeaderID = Guid.NewGuid().ToString();
        public string InvoiceHeaderId { get; set; }
        public int PaymentType { get; set; }
        public decimal SummaryNetAmount { get; set; }

        private bool isNegativ = false;
        private decimal cashLarge = 0;
        private decimal cashless = 0;
        private decimal bonus = 0;

        public FormPayment(int PaymentType, decimal SummaryNetAmount, string InvoiceHeaderId)
        {
            InitializeComponent();
            AcceptButton = simpleButtonOk;
            CancelButton = simpleButtonCancel;

            if (SummaryNetAmount < 0)
                isNegativ = true;
            this.PaymentType = PaymentType;
            this.SummaryNetAmount = SummaryNetAmount;
            this.InvoiceHeaderId = InvoiceHeaderId;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            switch (PaymentType)
            {
                case 1:
                    textEditCash.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                case 2:
                    textEditCashless.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                case 3:
                    textEditBonus.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                default:
                    textEditCash.EditValue = Math.Abs(SummaryNetAmount);
                    break;
            }
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            textEditCash.DoValidate();
            decimal txtCash = Convert.ToDecimal(textEditCash.EditValue);
            cashLarge = isNegativ ? txtCash * (-1) : txtCash;
        }

        private void textEditCash_Validating(object sender, CancelEventArgs e)
        {
            if (isNegativ)
            {
                if (cashLarge > 0)
                    e.Cancel = true;
            }
            else if (cashLarge < 0)
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
            decimal restAmount = SummaryNetAmount - cashless + bonus;
            if (restAmount >= 0)
                textEditCash.EditValue = restAmount;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            textEditCashless.DoValidate();
            decimal txtCashless = Convert.ToDecimal(textEditCashless.EditValue);
            cashless = isNegativ ? txtCashless * (-1) : txtCashless;
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            //if (cashless < 0)
            //    e.Cancel = true;
            //else if (cashless > SummaryNetAmount)
            //    e.Cancel = true;

            if (!cashless.Between(0, SummaryNetAmount, false))
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
            decimal restAmount = SummaryNetAmount - cashLarge + bonus;
            if (restAmount >= 0)
                textEditCashless.EditValue = restAmount;
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            textEditBonus.DoValidate();
            decimal txtBonus = Convert.ToDecimal(textEditBonus.EditValue);
            bonus = isNegativ ? txtBonus * (-1) : txtBonus;
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
            //if (bonus < 0)
            //    e.Cancel = true;
            //else if (bonus > SummaryNetAmount)
            //    e.Cancel = true;

            if (!cashless.Between(0, SummaryNetAmount, false))
                e.Cancel = true;
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən " + SummaryNetAmount + "dan çox olmamalıdır";
        }

        private void simpleButtonUpdateBonus_Click(object sender, EventArgs e)
        {
            decimal restAmount = SummaryNetAmount - cashLarge + cashless;
            if (restAmount >= 0)
                textEditBonus.EditValue = restAmount;
        }

        private void simpleButtonNum_Click(object sender, EventArgs e)
        {
            string key = (sender as SimpleButton).Text;

            switch (key)
            {
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "↵":
                    simpleButtonOk.PerformClick();
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            SqlMethods sqlMethods = new SqlMethods();
            string NewDocNum = sqlMethods.GetNextDocNum("P", "DocumentNumber", "trPaymentHeader");

            if ((cashLarge + cashless + bonus) >= SummaryNetAmount)
            {
                decimal cash = SummaryNetAmount - cashless - bonus;
                if (!sqlMethods.PaymentHeaderExist(InvoiceHeaderId))
                {
                    trPaymentHeader trPayment = new trPaymentHeader()
                    {
                        PaymentHeaderID = PaymentHeaderID,
                        DocumentNumber = NewDocNum,
                        InvoiceHeaderId = InvoiceHeaderId
                    };
                    sqlMethods.InsertPaymentHeader(trPayment);

                    if (cash != 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = cash,
                            PaymentTypeCode = 1
                        };
                        sqlMethods.InsertPaymentLine(trPaymentLine);
                    }

                    if (cashless != 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = cashless,
                            PaymentTypeCode = 2
                        };
                        sqlMethods.InsertPaymentLine(trPaymentLine);
                    }

                    if (bonus != 0)
                    {
                        trPaymentLine trPaymentLine = new trPaymentLine()
                        {
                            PaymentLineID = Guid.NewGuid().ToString(),
                            PaymentHeaderID = PaymentHeaderID,
                            Payment = bonus,
                            PaymentTypeCode = 3
                        };
                        sqlMethods.InsertPaymentLine(trPaymentLine);
                    }
                }

                decimal change = cash + cashless + bonus - SummaryNetAmount;
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