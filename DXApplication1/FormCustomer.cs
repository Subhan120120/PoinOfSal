using DevExpress.XtraEditors;
using PointOfSale.Models;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCustomer : XtraForm
    {
        SqlMethods sqlMethods = new SqlMethods();
        public DcCurrAcc DcCurrAcc { get; set; }
        public FormCustomer(DcCurrAcc DcCurrAcc)
        {
            this.DcCurrAcc = DcCurrAcc;
            InitializeComponent();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            string newNum = sqlMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");            

            DcCurrAcc = new DcCurrAcc()
            {
                CurrAccCode = newNum,
                CurrAccTypeCode = 2,
                Address = memoEdit_Address.EditValue is null ? "" : memoEdit_Address.EditValue.ToString(),
                BonusCardNum = txtEdit_BonusCard.EditValue is null ? "" : txtEdit_BonusCard.EditValue.ToString(),
                FirstName = txtEdit_FirstName.EditValue is null ? "" : txtEdit_FirstName.EditValue.ToString(),
                LastName = txtEdit_LastName.EditValue is null ? "" : txtEdit_LastName.EditValue.ToString(),
                BirthDate = txtEdit_BirthDate.EditValue is null ? null : Convert.ToDateTime(txtEdit_BirthDate.EditValue),
                PhoneNum = txtEdit_PhoneNum.EditValue is null ? "" : txtEdit_PhoneNum.EditValue.ToString()
            };

            int result = sqlMethods.InsertCustomer(DcCurrAcc);
            if (result > 0)
                DialogResult = DialogResult.OK;
        }
    }
}