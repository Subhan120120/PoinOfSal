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
        SqlMethods sqlMethods = new SqlMethods();
        public DcCurrAcc DcCurrAcc { get; set; }

        public FormCurrAccList()
        {
            InitializeComponent();

        }

        private void FormCurrAccList_Load(object sender, EventArgs e)
        {
            gC_CurrAccList.DataSource = sqlMethods.SelectCurrAccs();
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