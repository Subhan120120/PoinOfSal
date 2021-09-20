using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCustomer : XtraForm
    {
        SqlMethods sqlMethods = new SqlMethods();
        public dcCurrAcc dcCurrAcc { get; set; }
        public FormCustomer(dcCurrAcc dcCurrAcc)
        {
            this.dcCurrAcc = dcCurrAcc;
            InitializeComponent();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            string newNum = sqlMethods.GetNextDocNum("CA", "CurrAccCode", "dcCurrAcc");            

            dcCurrAcc = new dcCurrAcc()
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

            int result = sqlMethods.InsertCustomer(dcCurrAcc);
            if (result > 0)
                DialogResult = DialogResult.OK;
        }
    }
}