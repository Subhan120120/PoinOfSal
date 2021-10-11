using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PointOfSale.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCurrAccList : XtraForm
    {
        EfMethods efMethods = new EfMethods();
        public DcCurrAcc DcCurrAcc { get; set; }

        public FormCurrAccList()
        {
            InitializeComponent();
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_CurrAccList.RestoreLayoutFromXml(@"D:\GvListDefaultLayout.xml", option);
        }

        private void FormCurrAccList_Load(object sender, EventArgs e)
        {
            gC_CurrAccList.DataSource = efMethods.SelectCurrAccs();
        }

        private void gV_CurrAccList_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                //info.RowHandle
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                DcCurrAcc = new DcCurrAcc()
                {
                    CurrAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]).ToString()
                };
                DialogResult = DialogResult.OK;
            }
        }
    }
}