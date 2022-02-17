using DevExpress.XtraEditors;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PointOfSale
{
    public partial class FormCurrAcc : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new EfMethods();


        public DcCurrAcc dcCurrAcc = new DcCurrAcc();
        public FormCurrAcc()
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;



        }

        public FormCurrAcc(string currAccCode)
            : this()
        {
            dcCurrAcc.CurrAccCode = currAccCode;
        }

        private void FormCurrAcc_Load(object sender, EventArgs e)
        {
            //ClearControls();

            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcCurrAcc.CurrAccCode))
            {
                dcCurrAccsBindingSource.AddNew();
            }

            dbContext.DcCurrAccs.Where(x => x.CurrAccCode == dcCurrAcc.CurrAccCode)
                   .LoadAsync()
                   .ContinueWith(loadTask => dcCurrAccsBindingSource.DataSource = dbContext.DcCurrAccs.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());


        }

        private void ClearControls()
        {
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void dcCurrAccsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            dcCurrAcc = new DcCurrAcc();
            dcCurrAcc.CurrAccCode = efMethods.GetNextDocNum("CA", "CurrAccCode", "DcCurrAccs");
            dcCurrAcc.DataLanguageCode = "AZ";
            e.NewObject = dcCurrAcc;



        }

        private void dataLayoutControl1_FieldRetrieving(object sender, DevExpress.XtraDataLayout.FieldRetrievingEventArgs e)
        {
            if (e.FieldName == "ModifiedDate")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }
    }
}
