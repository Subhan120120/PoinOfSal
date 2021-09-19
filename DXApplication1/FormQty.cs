using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormQty : XtraForm
    {
        public int maxQty { get; set; }
        public int qty { get; set; }

        public FormQty()
        {
            InitializeComponent();
            AcceptButton = simpleButtonOk;
            CancelButton = simpleButtonCancel;
        }

        public FormQty(int maxQty)
            : this()
        {
            this.maxQty = maxQty;
        }

        private void FormQty_Load(object sender, EventArgs e)
        {
            textEditQty.EditValue = maxQty;
        }

        private void textEditQty_EditValueChanged(object sender, EventArgs e)
        {
            qty = Convert.ToInt32(textEditQty.EditValue);
            textEditQty.DoValidate();
        }

        private void simpleButtonNum_Click(object sender, EventArgs e)
        {
            SimpleButton simpleButton = sender as SimpleButton;
            string key = simpleButton.Text;

            switch (key)
            {
                case "C":
                    SendKeys.Send("^A");
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case "←":
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
            DialogResult = DialogResult.OK;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textEditQty_Validating(object sender, CancelEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            decimal val = Convert.ToDecimal(textEdit.EditValue);
            if (val <= 0)
                e.Cancel = true;
            else if (val > maxQty && maxQty != 0)
                e.Cancel = true;
            else
                labelMessage.Text = "";
        }

        private void textEditQty_InvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            e.WindowCaption = "Diqqət";
            e.ErrorText = "Dəyər 0 ilə "+ maxQty.ToString() + " arasında olmalıdır";
            labelMessage.Text = e.ErrorText;
        }
    }
}