using DevExpress.XtraEditors;
using DXApplication1.Model;
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
            string newNum = sqlMethods.GetNextNumber("CurrAccCode", "dcCurrAcc");            

            dcCurrAcc = new dcCurrAcc()
            {
                CurrAccCode = "C-2-" + newNum,
                CurrAccType = 2,
                Address = memoEditAddress.EditValue is null ? "" : memoEditAddress.EditValue.ToString(),
                BonusCardNum = textEditBonusCard.EditValue is null ? "" : textEditBonusCard.EditValue.ToString(),
                FirstName = textEditFirstName.EditValue is null ? "" : textEditFirstName.EditValue.ToString(),
                LastName = textEditLastName.EditValue is null ? "" : textEditLastName.EditValue.ToString(),
                PhoneNum = textEditPhoneNum.EditValue is null ? "" : textEditPhoneNum.EditValue.ToString()
            };

            int result = sqlMethods.InsertCustomer(dcCurrAcc);
            if (result > 0)
                DialogResult = DialogResult.OK;
        }
    }
}