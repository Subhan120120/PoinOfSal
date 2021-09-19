using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class FormLogin : XtraForm
    {        
        public FormLogin()
        {
            InitializeComponent();
            //System.Threading.Thread.Sleep(7000);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FormPOS formPos = new FormPOS();
            Hide();
            formPos.ShowDialog();
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormERP formERP = new FormERP();
            Hide();
            formERP.ShowDialog();
            Close();
        }
    }
}