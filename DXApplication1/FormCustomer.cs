﻿using DevExpress.XtraEditors;
using PointOfSale.Models;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCustomer : XtraForm
    {
        EfMethods efMethods = new EfMethods();
        public DcCurrAcc DcCurrAcc { get; set; }


        public FormCustomer(DcCurrAcc DcCurrAcc)
        {
            this.DcCurrAcc = DcCurrAcc;
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DcCurrAcc.CurrAccCode))
            {
                txtEdit_CurrAccCode.EditValue = DcCurrAcc.CurrAccCode;
                txtEdit_FirstName.EditValue = DcCurrAcc.FirstName;
                memoEdit_Address.EditValue = DcCurrAcc.Address;
                dateEdit_BirthDate.EditValue = DcCurrAcc.BirthDate;
                txtEdit_BonusCard.EditValue = DcCurrAcc.BonusCardNum;
                txtEdit_PhoneNum.EditValue = DcCurrAcc.PhoneNum;
            }
            else
                txtEdit_CurrAccCode.EditValue = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DcCurrAcc = efMethods.SelectCurrAcc(txtEdit_CurrAccCode.Text);
            if (DcCurrAcc == null)                                      // if Customer doesnt exist in db
                DcCurrAcc = new DcCurrAcc();

            DcCurrAcc.CurrAccCode = txtEdit_CurrAccCode.Text;
            DcCurrAcc.CurrAccTypeCode = 2;
            DcCurrAcc.Address = memoEdit_Address.Text;
            DcCurrAcc.BonusCardNum = txtEdit_BonusCard.Text;
            DcCurrAcc.FirstName = txtEdit_FirstName.Text;
            DcCurrAcc.LastName = txtEdit_LastName.Text;
            DcCurrAcc.BirthDate = Convert.ToDateTime(dateEdit_BirthDate.EditValue ?? new DateTime(1901, 01, 01));
            DcCurrAcc.PhoneNum = txtEdit_PhoneNum.Text;

            if (efMethods.CustomerExist(txtEdit_CurrAccCode.Text))
                efMethods.UpdateCustomer(DcCurrAcc);
            else
                efMethods.InsertCustomer(DcCurrAcc);

            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}