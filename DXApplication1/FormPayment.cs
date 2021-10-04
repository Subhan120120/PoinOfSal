using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using PointOfSale.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormPayment : XtraForm
    {
        public Guid PaymentHeaderId = Guid.NewGuid();
        public Guid InvoiceHeaderId { get; set; }
        public int PaymentType { get; set; }
        public decimal SummaryNetAmount { get; set; }

        private bool isNegativ = false;
        private decimal cashLarge = 0;
        private decimal cashless = 0;
        private decimal bonus = 0;

        public FormPayment(int PaymentType, decimal SummaryNetAmount, Guid InvoiceHeaderId)
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

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
                    txt_EditCash.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                case 2:
                    txtEdit_Cashless.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                case 3:
                    txtEdit_Bonus.EditValue = Math.Abs(SummaryNetAmount);
                    break;
                default:
                    txt_EditCash.EditValue = Math.Abs(SummaryNetAmount);
                    break;
            }
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            txt_EditCash.DoValidate();
            decimal txtCash = Convert.ToDecimal(txt_EditCash.EditValue);
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
                txt_EditCash.EditValue = restAmount;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_Cashless.DoValidate();
            decimal txtCashless = Convert.ToDecimal(txtEdit_Cashless.EditValue);
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
                txtEdit_Cashless.EditValue = restAmount;
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_Bonus.DoValidate();
            decimal txtBonus = Convert.ToDecimal(txtEdit_Bonus.EditValue);
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
                txtEdit_Bonus.EditValue = restAmount;
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
                    btn_Ok.PerformClick();
                    break;
                default:
                    SendKeys.Send(key);
                    break;
            }
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            SqlMethods sqlMethods = new SqlMethods();
            string NewDocNum = sqlMethods.GetNextDocNum("P", "DocumentNumber", "TrPaymentHeaders");

            if ((cashLarge + cashless + bonus) >= SummaryNetAmount)
            {
                decimal cash = SummaryNetAmount - cashless - bonus;
                if (!sqlMethods.PaymentHeaderExist(InvoiceHeaderId))
                {
                    TrPaymentHeader trPayment = new TrPaymentHeader()
                    {
                        PaymentHeaderId = PaymentHeaderId,
                        DocumentNumber = NewDocNum,
                        InvoiceHeaderId = InvoiceHeaderId
                    };
                    sqlMethods.InsertPaymentHeader(trPayment);

                    if (cash != 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = cash,
                            PaymentTypeCode = 1
                        };
                        sqlMethods.InsertPaymentLine(TrPaymentLine);
                    }

                    if (cashless != 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = cashless,
                            PaymentTypeCode = 2
                        };
                        sqlMethods.InsertPaymentLine(TrPaymentLine);
                    }

                    if (bonus != 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = bonus,
                            PaymentTypeCode = 3
                        };
                        sqlMethods.InsertPaymentLine(TrPaymentLine);
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