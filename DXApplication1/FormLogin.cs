using DevExpress.XtraEditors;
using System;

namespace PointOfSale
{
    public partial class FormLogin : XtraForm
    {
        EfMethods efMethods = new EfMethods();

        public FormLogin()
        {
            InitializeComponent();
            //System.Threading.Thread.Sleep(7000);

            string layout = efMethods.SelectAppSettingGridViewLayout();
            //byte[] byteArray = Encoding.ASCII.GetBytes(layout);
            Properties.Settings.Default.GridViewLayout = layout;
            Properties.Settings.Default.Save();

            txtEdit_UserName.Text = Properties.Settings.Default.LoginName;
            txtEdit_Password.Text = Properties.Settings.Default.LoginPassword;
            checkEdit_RemindMe.Checked = Properties.Settings.Default.LoginChecked;
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
            {
                FormPOS formPos = new FormPOS();
                Hide();
                formPos.ShowDialog();
                Close();
            }
        }


        private void btn_ERP_Click(object sender, EventArgs e)
        {
            if (Login(txtEdit_UserName.Text, txtEdit_Password.Text))
            {
                FormERP formERP = new FormERP();
                Hide();
                formERP.ShowDialog();
                Close();
            }
            else
                XtraMessageBox.Show("İstifadəçi və ya şifrə yanlışdır");
        }

        public bool Login(string user, string password)
        {
            if (efMethods.CurrAccExist(user, password))
            {
                SessionSave();
                return true;
            }
            else
                return false;
        }

        private void SessionSave()
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
            Session.DcRoles = efMethods.SelectRoles(txtEdit_UserName.Text);
        }
    }
}