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
        public decimal SumNetAmount { get; set; }

        private bool isNegativ = false;
        private decimal cashLarge = 0;
        private decimal cashless = 0;
        private decimal bonus = 0;

        public FormPayment(int PaymentType, decimal SumNetAmount, Guid InvoiceHeaderId)
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;

            if (SumNetAmount < 0)
                isNegativ = true;

            this.PaymentType = PaymentType;
            this.SumNetAmount = Math.Abs(SumNetAmount);
            this.InvoiceHeaderId = InvoiceHeaderId;
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            switch (PaymentType)
            {
                case 1:
                    txt_EditCash.EditValue = SumNetAmount;
                    break;
                case 2:
                    txtEdit_Cashless.EditValue = SumNetAmount;
                    break;
                case 3:
                    txtEdit_Bonus.EditValue = SumNetAmount;
                    break;
                default:
                    txt_EditCash.EditValue = SumNetAmount;
                    break;
            }
        }

        private void textEditCash_EditValueChanged(object sender, EventArgs e)
        {
            txt_EditCash.DoValidate();
            decimal txtCash = Convert.ToDecimal(txt_EditCash.EditValue);
            cashLarge = txtCash;
        }

        private void textEditCash_Validating(object sender, CancelEventArgs e)
        {
            if (cashLarge < 0)
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
            decimal restAmount = SumNetAmount - cashless + bonus;
            if (restAmount >= 0)
                txt_EditCash.EditValue = restAmount;
        }

        private void textEditCashless_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_Cashless.DoValidate();
            decimal txtCashless = Convert.ToDecimal(txtEdit_Cashless.EditValue);
            cashless = txtCashless;
        }

        private void textEditCashless_Validating(object sender, CancelEventArgs e)
        {
            if (!cashless.Between(0, SumNetAmount, true))
                e.Cancel = true;
        }

        private void textEditCashless_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən (" + SumNetAmount + "'dan) çox olmamalıdır";
        }

        private void simpleButtonUpdateCashless_Click(object sender, EventArgs e)
        {
            decimal restAmount = SumNetAmount - cashLarge + bonus;
            if (restAmount >= 0)
                txtEdit_Cashless.EditValue = restAmount;
        }

        private void textEditBonus_EditValueChanged(object sender, EventArgs e)
        {
            txtEdit_Bonus.DoValidate();
            decimal txtBonus = Convert.ToDecimal(txtEdit_Bonus.EditValue);
            bonus = txtBonus;
        }

        private void textEditBonus_Validating(object sender, CancelEventArgs e)
        {
            if (!cashless.Between(0, SumNetAmount, true))
                e.Cancel = true;
        }

        private void textEditBonus_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər ödenilmeli məbləğdən " + SumNetAmount + "dan çox olmamalıdır";
        }

        private void simpleButtonUpdateBonus_Click(object sender, EventArgs e)
        {
            decimal restAmount = SumNetAmount - cashLarge + cashless;
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
            EfMethods efMethods = new EfMethods();
            AdoMethods adoMethods = new AdoMethods();

            string NewDocNum = adoMethods.GetNextDocNum("P", "DocumentNumber", "TrPaymentHeaders");

            if ((cashLarge + cashless + bonus) >= SumNetAmount)
            {
                decimal cash = SumNetAmount - cashless - bonus;
                if (!efMethods.PaymentHeaderExist(InvoiceHeaderId))
                {
                    TrPaymentHeader trPayment = new TrPaymentHeader()
                    {
                        PaymentHeaderId = PaymentHeaderId,
                        DocumentNumber = NewDocNum,
                        InvoiceHeaderId = InvoiceHeaderId
                    };
                    efMethods.InsertPaymentHeader(trPayment);

                    if (cash > 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = isNegativ ? cash * (-1) : cash,
                            PaymentTypeCode = 1
                        };
                        efMethods.InsertPaymentLine(TrPaymentLine);
                    }

                    if (cashless > 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = isNegativ ? cashless * (-1) : cashless,
                            PaymentTypeCode = 2
                        };
                        efMethods.InsertPaymentLine(TrPaymentLine);
                    }

                    if (bonus > 0)
                    {
                        TrPaymentLine TrPaymentLine = new TrPaymentLine()
                        {
                            PaymentLineId = Guid.NewGuid(),
                            PaymentHeaderId = PaymentHeaderId,
                            Payment = isNegativ ? bonus * (-1) : bonus,
                            PaymentTypeCode = 3
                        };
                        efMethods.InsertPaymentLine(TrPaymentLine);
                    }
                }

                decimal change = cashLarge + cashless + bonus - SumNetAmount;
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
                XtraMessageBox.Show("Ödəmə ödənilməli olan məbləğdən azdır");
        }
    }
}