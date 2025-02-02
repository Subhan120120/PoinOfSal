﻿using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using PointOfSale.Properties;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormProductList : RibbonForm
    {
        EfMethods efMethods = new EfMethods();
        public DcProduct dcProduct { get; set; }
        public byte productTypeCode;

        public FormProductList()
        {
            InitializeComponent();
            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_ProductList.RestoreLayoutFromStream(stream, option);
        }

        public FormProductList(byte productTypeCode)
            : this()
        {
            this.productTypeCode = productTypeCode;
            if (productTypeCode != 0)
                gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
            else
                gC_ProductList.DataSource = efMethods.SelectProducts();
        }

        private void gV_ProductList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
                dcProduct = view.GetRow(view.FocusedRowHandle) as DcProduct;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            #region Comment
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if ((info.InRow || info.InRowCell) && view.FocusedRowHandle >= 0)
            //{
            //    //info.RowHandle
            //    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
            //    dcProduct = new DcProduct()
            //    {
            //        ProductCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductCode"]).ToString(),
            //        Barcode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Barcode"]).ToString(),
            //        ProductDescription = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductDescription"]).ToString(),
            //        RetailPrice = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RetailPrice"]))
            //    };
            //} 
            #endregion

            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                DialogResult = DialogResult.OK;
        }

        private void BBI_ProductNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                if (productTypeCode != 0)
                    gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
                else
                    gC_ProductList.DataSource = efMethods.SelectProducts();
            }

        }

        private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct(dcProduct.ProductCode);

            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                int fr = gV_ProductList.FocusedRowHandle;

                if (productTypeCode != 0)
                    gC_ProductList.DataSource = efMethods.SelectProductsByProductType(productTypeCode);
                else
                    gC_ProductList.DataSource = efMethods.SelectProducts();

                gV_ProductList.FocusedRowHandle = fr;
            }
        }
    }
}