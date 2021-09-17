using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Windows.Forms;
namespace DXApplication1
{
    public partial class FormInvoice : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public string invoiceHeaderId = Guid.NewGuid().ToString();

        SqlMethods sqlMethods = new SqlMethods();

        public FormInvoice()
        {
            InitializeComponent();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = bbiSave;
            badge2.TargetElement = mainRibbonPage;
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            textEditOfficeCode.Properties.DataSource = sqlMethods.SelectOffice(); 
            textEditStoreCode.Properties.DataSource = sqlMethods.SelectStore();
            textEditWarehouseCode.Properties.DataSource = sqlMethods.SelectWarehouse(); 
        }

        private void buttonEditDocNum_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

        }

        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void buttonEditCurrAccCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (FormCurrAccList form = new FormCurrAccList())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEditCurrAccCode.EditValue = form.dcCurrAcc.CurrAccCode;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            MessageBox.Show("gridView1_InitNewRow");
        }
    }
}