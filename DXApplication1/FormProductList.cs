using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using PointOfSale.Models;
using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormProductList : RibbonForm
    {
        public DcProduct dcProduct { get; set; }
        EfMethods efMethods = new EfMethods();

        public FormProductList()
        {



            InitializeComponent();
            byte[] byteArray = Encoding.ASCII.GetBytes(Properties.Settings.Default.GridViewLayout);
            MemoryStream stream = new MemoryStream(byteArray);
            OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            gV_ProductList.RestoreLayoutFromStream(stream, option);
            


            //Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PointOfSale.AppCode.GvListDefaultLayout.xml");
            //OptionsLayoutGrid option = new OptionsLayoutGrid() { StoreAllOptions = true, StoreAppearance = true };
            //this.gV_ProductList.RestoreLayoutFromStream(stream, option);


            gC_ProductList.DataSource = efMethods.SelectProducts();
        }



        private void gV_ProductList_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle >= 0)
            {
                dcProduct = new DcProduct();
                dcProduct.ProductCode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductCode"]).ToString();
                dcProduct.Barcode = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Barcode"]).ToString();
                dcProduct.ProductDescription = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["ProductDescription"]).ToString();
                dcProduct.RetailPrice = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RetailPrice"]));
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
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

            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
                DialogResult = DialogResult.OK;
        }

        private void BBI_ProductNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct();
            if (formProduct.ShowDialog(this) == DialogResult.OK)
                gC_ProductList.DataSource = efMethods.SelectProducts();

        }

        private void btn_productEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormProduct formProduct = new FormProduct(dcProduct.ProductCode);

            if (formProduct.ShowDialog(this) == DialogResult.OK)
            {
                int fr = gV_ProductList.FocusedRowHandle;
                gC_ProductList.DataSource = efMethods.SelectProducts();
                gV_ProductList.FocusedRowHandle = fr;
            }
        }
    }
}