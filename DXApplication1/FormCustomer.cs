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
            string newNum = sqlMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAcc");            

            DcCurrAcc = new DcCurrAcc()
            {
                CurrAccCode = newNum,
                CurrAccTypeCode = 2,
                Address = memoEditAddress.EditValue is null ? "" : memoEditAddress.EditValue.ToString(),
                BonusCardNum = textEditBonusCard.EditValue is null ? "" : textEditBonusCard.EditValue.ToString(),
                FirstName = textEditFirstName.EditValue is null ? "" : textEditFirstName.EditValue.ToString(),
                LastName = textEditLastName.EditValue is null ? "" : textEditLastName.EditValue.ToString(),
                BirthDate = textEditBirthDate.EditValue is null ? null : Convert.ToDateTime(textEditBirthDate.EditValue),
                PhoneNum = textEditPhoneNum.EditValue is null ? "" : textEditPhoneNum.EditValue.ToString()
            };

            int result = sqlMethods.InsertCustomer(DcCurrAcc);
            if (result > 0)
                DialogResult = DialogResult.OK;
        }
    }
}