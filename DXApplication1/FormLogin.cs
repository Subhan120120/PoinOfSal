﻿using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
        EfMethods efMethods = new EfMethods();

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