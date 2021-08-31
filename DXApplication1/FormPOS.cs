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
    public partial class FormPOS : XtraForm
    {
        public FormPOS()
        {
            InitializeComponent();

        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            UcSale ucSale = new UcSale();
            ucSale.Dock = DockStyle.Fill;
            AcceptButton = ucSale.simpleButtonEnter;
            navigationPageSale.Controls.Add(ucSale);
        }

        private void officeNavigationBar1_ItemClick(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (e.Item.Text == "Exit")
                this.Close();
        }
    }
}