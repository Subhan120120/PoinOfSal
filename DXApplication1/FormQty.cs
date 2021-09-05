using DevExpress.XtraEditors;
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
                    DialogResult = DialogResult.OK;
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

        
    }
}