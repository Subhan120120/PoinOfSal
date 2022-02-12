using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PointOfSale.Models;
using PointOfSale.Properties;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormInvoiceHeaderList : XtraForm
    {
        public FormInvoiceHeaderList()
        {
            InitializeComponent();
            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            this.gV_InvoiceHeaderList.RestoreLayoutFromStream(stream, option);
        }

        public TrInvoiceHeader TrInvoiceHeader { get; set; }
        EfMethods efMethods = new EfMethods();

        private void FormInvoiceHeaderList_Load(object sender, EventArgs e)
        {
            gC_InvoiceHeaderList.DataSource = efMethods.SelectInvoiceHeaders();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            {
                //info.RowHandle
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();              

                TrInvoiceHeader = view.GetRow(view.FocusedRowHandle) as TrInvoiceHeader;

                DialogResult = DialogResult.OK;
            }
        }
    }
}