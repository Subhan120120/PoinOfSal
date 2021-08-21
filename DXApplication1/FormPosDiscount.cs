using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPosDiscount : XtraForm
    {
        decimal Amount = 0;
        decimal NetAmount = 0;
        public decimal PosDiscountRate = 0;
        public FormPosDiscount(decimal PosDiscountRate, decimal Amount)
        {
            this.Amount = Amount;
            this.PosDiscountRate = PosDiscountRate;

            InitializeComponent();
        }

        private void FormPosDiscount_Load(object sender, EventArgs e)
        {
            AcceptButton = simpleButtonOk;
            CancelButton = simpleButtonCancel;
            NetAmount = Math.Round(Amount - (Amount * PosDiscountRate / 100), 2);
            textEditDiscountRate.EditValue = PosDiscountRate.ToString();
            textEditNetAmount.EditValue = NetAmount.ToString();
        }

        private void textEditDiscountRate_EditValueChanged(object sender, EventArgs e)
        {
            textEditDiscountRate.DoValidate();
            PosDiscountRate = Math.Round(Convert.ToDecimal(textEditDiscountRate.EditValue.ToString()), 2);
            if (PosDiscountRate > 100)
                PosDiscountRate = 100;
            else if (PosDiscountRate < 0)
                PosDiscountRate = 0;

            NetAmount = Math.Round(Amount - (Amount * PosDiscountRate / 100), 2);
            textEditNetAmount.EditValueChanged -= new EventHandler(textEditNetAmount_EditValueChanged);
            textEditNetAmount.EditValue = (NetAmount.ToString());
            textEditNetAmount.EditValueChanged += new EventHandler(textEditNetAmount_EditValueChanged);
        }

        private void textEditNetAmount_EditValueChanged(object sender, EventArgs e)
        {
            textEditNetAmount.DoValidate();
            NetAmount = Math.Round(Convert.ToDecimal(textEditNetAmount.EditValue.ToString()), 2);
            if (NetAmount > Amount)
                NetAmount = Amount;
            else if (NetAmount < 0)
                NetAmount = 0;

            PosDiscountRate = Math.Round((Amount - NetAmount) / Amount * 100, 2);
            textEditDiscountRate.EditValueChanged -= new EventHandler(textEditDiscountRate_EditValueChanged);
            textEditDiscountRate.EditValue = (PosDiscountRate.ToString());
            textEditDiscountRate.EditValueChanged += new EventHandler(textEditDiscountRate_EditValueChanged);
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void textEditDiscountRate_Validating(object sender, CancelEventArgs e)
        {
            Validate_BetweenMinAndMaxRule(sender as BaseEdit, 0, 100);
        }
        private void textEditNetAmount_Validating(object sender, CancelEventArgs e)
        {
            Validate_BetweenMinAndMaxRule(sender as BaseEdit, 0, Amount);
        }

        private void Validate_BetweenMinAndMaxRule(BaseEdit control, decimal min, decimal max)
        {
            decimal val = Convert.ToDecimal(control.EditValue.ToString());
            if ((val < min)) dxErrorProvider1.SetError(control, "Endirim ədədi " + (min).ToString() + " dan böyük olmalıdır ", ErrorType.Critical);
            else if (val > max) dxErrorProvider1.SetError(control, "Endirim ədədi " + (max).ToString() + " dən kiçik olmalıdır ", ErrorType.Critical);
            else dxErrorProvider1.SetError(control, "");
        }

        private void textEditDiscountRate_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            MessageBox.Show("Enter a date within the current month.", "Error");
        }

        private void simpleButtonNum_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ",":
                case "*":
                    SendKeys.Send(key);
                    break;
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "←":
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "↵":
                    DialogResult = DialogResult.OK;
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
