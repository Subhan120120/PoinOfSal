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
        SqlMethods sqlMethods = new SqlMethods();

        public FormLogin()
        {
            InitializeComponent();
            //System.Threading.Thread.Sleep(7000);
            txtEdit_UserName.Text = Properties.Settings.Default.LoginName;
            txtEdit_Password.Text = Properties.Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Properties.Settings.Default.LoginChecked;
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            if (sqlMethods.CurrAccExist(txtEdit_UserName.Text, txtEdit_Password.Text))
            {
                SettingSave();

                FormPOS formPos = new FormPOS();
                Hide();
                formPos.ShowDialog();
                Close();
            }
        }


        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (sqlMethods.CurrAccExist(txtEdit_UserName.Text, txtEdit_Password.Text))
            {
                SettingSave();

                FormERP formERP = new FormERP();
                Hide();
                formERP.ShowDialog();
                Close();
            }
        }

        private void SettingSave()
        {
            if (checkEdit_RemindMe.Checked)
            {
                Properties.Settings.Default.LoginName = txtEdit_UserName.Text;
                Properties.Settings.Default.LoginPassword = txtEdit_Password.Text;
                Properties.Settings.Default.LoginChecked = checkEdit_RemindMe.Checked;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.LoginName = string.Empty;
                Properties.Settings.Default.LoginPassword = string.Empty;
                Properties.Settings.Default.LoginChecked = false;
                Properties.Settings.Default.Save();
            }

            Session.CurrAccCode = txtEdit_UserName.Text;
            Session.DcRoles = sqlMethods.SelectRoles(txtEdit_UserName.Text);
        }
    }
}