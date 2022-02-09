﻿using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormCurrAccList : RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        public DcCurrAcc dcCurrAcc { get; set; }

        public FormCurrAccList()
        {
            InitializeComponent();
            byte[] byteArray = Encoding.ASCII.GetBytes(Properties.Settings.Default.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_CurrAccList.RestoreLayoutFromStream(stream, option);
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
                dcCurrAcc = new DcCurrAcc();                
                string CurrAccCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CurrAccCode"]).ToString();
                dcCurrAcc = efMethods.SelectCurrAcc(CurrAccCode);

                DialogResult = DialogResult.OK;

                FormCurrAcc form = new FormCurrAcc(dcCurrAcc);
                form.Show();
            }
        }

        private void bBI_CurrAccNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bBI_CurrAccEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}