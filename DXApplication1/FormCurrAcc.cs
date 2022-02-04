using DevExpress.XtraEditors;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCurrAcc : XtraForm
    {
        DcCurrAcc dcCurrAcc;
        public FormCurrAcc(DcCurrAcc dcCurrAcc)
        {
            this.dcCurrAcc = dcCurrAcc;
            InitializeComponent();
        }

        private void FormCurrAcc_Load(object sender, EventArgs e)
        {

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
