using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PointOfSale.Models;
using System;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormInvoiceHeaderList : XtraForm
    {
        public FormInvoiceHeaderList()
        {
            InitializeComponent();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            this.gV_InvoiceHeaderList.RestoreLayoutFromXml(@"D:\GvListDefaultLayout.xml", option);
        }

        public TrInvoiceHeader TrInvoiceHeader { get; set; }
        SqlMethods sqlMethods = new SqlMethods();

        private void FormInvoiceHeaderList_Load(object sender, EventArgs e)
        {
            gC_InvoiceHeaderList.DataSource = sqlMethods.SelectInvoiceHeaders();
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

                object currAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]);
                string currAcc = currAccCode == null ? null : currAccCode.ToString();

                TrInvoiceHeader = new TrInvoiceHeader()
                {
                    InvoiceHeaderId = (Guid)view.GetRowCellValue(view.FocusedRowHandle, view.Columns["InvoiceHeaderId"]),
                    ProcessCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProcessCode"]).ToString(),
                    DocumentNumber = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DocumentNumber"]).ToString(),
                    IsReturn = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["IsReturn"])),
                    CustomsDocumentNumber = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CustomsDocumentNumber"]).ToString(),
                    DocumentDate = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DocumentDate"])),
                    DocumentTime = (TimeSpan)(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["DocumentTime"])),
                    CurrAccCode = currAcc,
                    OfficeCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["OfficeCode"]).ToString(),
                    StoreCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["StoreCode"]).ToString(),
                    WarehouseCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["WarehouseCode"]).ToString(),
                    Description = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Description"]).ToString(),
                };
                DialogResult = DialogResult.OK;
            }
        }
    }
}