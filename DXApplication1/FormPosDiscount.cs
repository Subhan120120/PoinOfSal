using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPosDiscount : XtraForm
    {
        float Amount = 0;
        float NetAmount = 0;
        public float PosDiscountRate = 0;
        public FormPosDiscount(float PosDiscountRate, float Amount)
        {
            this.Amount = Amount;
            this.PosDiscountRate = PosDiscountRate;
            
            InitializeComponent();
        }

        private void FormPosDiscount_Load(object sender, EventArgs e)
        {
            AcceptButton = simpleButtonOk;
            CancelButton = simpleButtonCancel;
            NetAmount = Amount - (Amount * PosDiscountRate / 100);
            textEditDiscountRate.Text = PosDiscountRate.ToString();
            textEditNetAmount.Text = NetAmount.ToString();
        }

        private void textEditDiscountRate_EditValueChanged(object sender, EventArgs e)
        {
            textEditDiscountRate.DoValidate();
            PosDiscountRate = float.Parse(textEditDiscountRate.EditValue.ToString());
            if (PosDiscountRate > 100)
                PosDiscountRate = 100;
            else if (PosDiscountRate < 0)
                PosDiscountRate = 0;

            NetAmount = Amount - (Amount * PosDiscountRate / 100);
            textEditNetAmount.EditValueChanged -= new EventHandler(textEditNetAmount_EditValueChanged);            
            textEditNetAmount.Text = (NetAmount.ToString());
            textEditNetAmount.EditValueChanged += new EventHandler(textEditNetAmount_EditValueChanged);
        }

        private void textEditNetAmount_EditValueChanged(object sender, EventArgs e)
        {
            textEditNetAmount.DoValidate();
            NetAmount = float.Parse(textEditNetAmount.EditValue.ToString());
            if (NetAmount > Amount)
                NetAmount = Amount;
            else if (NetAmount < 0)
                NetAmount = 0;

            PosDiscountRate = (Amount - NetAmount) / Amount * 100;
            textEditDiscountRate.EditValueChanged -= new EventHandler(textEditDiscountRate_EditValueChanged);
            textEditDiscountRate.Text = (PosDiscountRate.ToString());
            textEditDiscountRate.EditValueChanged += new EventHandler(textEditDiscountRate_EditValueChanged);
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void textEditDiscountRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validate_BetweenMinAndMaxRule(sender as BaseEdit, 0, 100);
        }
        private void textEditNetAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validate_BetweenMinAndMaxRule(sender as BaseEdit, 0, Amount);
        }

        private void Validate_BetweenMinAndMaxRule(BaseEdit control, float min, float max)
        {
            //if (!(control.EditValue is decimal)) return;
            float val = float.Parse(control.EditValue.ToString());
            if ((val < min)) dxErrorProvider1.SetError(control, "Endirim ədədi " + (min).ToString() + " dan böyük olmalıdır ", ErrorType.Critical);
            else if (val > max) dxErrorProvider1.SetError(control, "Endirim ədədi " + (max).ToString() + " dən kiçik olmalıdır ", ErrorType.Critical);
            else dxErrorProvider1.SetError(control, "");
        }

        private void textEditDiscountRate_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            MessageBox.Show("Enter a date within the current month.", "Error");
        }

    }
}
