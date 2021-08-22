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
    public partial class FormChange : XtraForm
    {
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public FormChange(decimal Cash, decimal Change)
        {
            InitializeComponent();
            this.Cash = Cash;
            this.Change = Change;
            AcceptButton = simpleButtonOk;
        }

        private void FormChange_Load(object sender, EventArgs e)
        {
            textEditCash.EditValue = Cash;
            textEditChange.EditValue = Change;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}