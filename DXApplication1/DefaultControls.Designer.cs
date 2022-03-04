
namespace PointOfSale
{
    partial class DefaultControls
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultControls));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dcProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWholesalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUseInternet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcProductType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrPrices = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrInvoiceLines = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrFeature = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_saveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_formLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_loadLayout = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.dcProductsBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 158);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1133, 314);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dcProductsBindingSource
            // 
            this.dcProductsBindingSource.DataSource = typeof(PointOfSale.Models.DcProduct);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductCode,
            this.colBarcode,
            this.colProductTypeCode,
            this.colUsePos,
            this.colPromotionCode,
            this.colPromotionCode2,
            this.colTaxRate,
            this.colPosDiscount,
            this.colIsDisabled,
            this.colRetailPrice,
            this.colPurchasePrice,
            this.colWholesalePrice,
            this.colUseInternet,
            this.colProductDescription,
            this.colDcProductType,
            this.colTrPrices,
            this.colTrInvoiceLines,
            this.colTrFeature,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 1;
            // 
            // colProductTypeCode
            // 
            this.colProductTypeCode.FieldName = "ProductTypeCode";
            this.colProductTypeCode.Name = "colProductTypeCode";
            this.colProductTypeCode.Visible = true;
            this.colProductTypeCode.VisibleIndex = 2;
            // 
            // colUsePos
            // 
            this.colUsePos.FieldName = "UsePos";
            this.colUsePos.Name = "colUsePos";
            this.colUsePos.Visible = true;
            this.colUsePos.VisibleIndex = 3;
            // 
            // colPromotionCode
            // 
            this.colPromotionCode.FieldName = "PromotionCode";
            this.colPromotionCode.Name = "colPromotionCode";
            this.colPromotionCode.Visible = true;
            this.colPromotionCode.VisibleIndex = 4;
            // 
            // colPromotionCode2
            // 
            this.colPromotionCode2.FieldName = "PromotionCode2";
            this.colPromotionCode2.Name = "colPromotionCode2";
            this.colPromotionCode2.Visible = true;
            this.colPromotionCode2.VisibleIndex = 5;
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 6;
            // 
            // colPosDiscount
            // 
            this.colPosDiscount.FieldName = "PosDiscount";
            this.colPosDiscount.Name = "colPosDiscount";
            this.colPosDiscount.Visible = true;
            this.colPosDiscount.VisibleIndex = 7;
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            this.colIsDisabled.Visible = true;
            this.colIsDisabled.VisibleIndex = 8;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 9;
            // 
            // colPurchasePrice
            // 
            this.colPurchasePrice.FieldName = "PurchasePrice";
            this.colPurchasePrice.Name = "colPurchasePrice";
            this.colPurchasePrice.Visible = true;
            this.colPurchasePrice.VisibleIndex = 10;
            // 
            // colWholesalePrice
            // 
            this.colWholesalePrice.FieldName = "WholesalePrice";
            this.colWholesalePrice.Name = "colWholesalePrice";
            this.colWholesalePrice.Visible = true;
            this.colWholesalePrice.VisibleIndex = 11;
            // 
            // colUseInternet
            // 
            this.colUseInternet.FieldName = "UseInternet";
            this.colUseInternet.Name = "colUseInternet";
            this.colUseInternet.Visible = true;
            this.colUseInternet.VisibleIndex = 12;
            // 
            // colProductDescription
            // 
            this.colProductDescription.FieldName = "ProductDescription";
            this.colProductDescription.Name = "colProductDescription";
            this.colProductDescription.Visible = true;
            this.colProductDescription.VisibleIndex = 13;
            // 
            // colDcProductType
            // 
            this.colDcProductType.FieldName = "DcProductType";
            this.colDcProductType.Name = "colDcProductType";
            this.colDcProductType.Visible = true;
            this.colDcProductType.VisibleIndex = 14;
            // 
            // colTrPrices
            // 
            this.colTrPrices.FieldName = "TrPrices.Price";
            this.colTrPrices.Name = "colTrPrices";
            this.colTrPrices.Visible = true;
            this.colTrPrices.VisibleIndex = 15;
            // 
            // colTrInvoiceLines
            // 
            this.colTrInvoiceLines.FieldName = "TrInvoiceLines";
            this.colTrInvoiceLines.Name = "colTrInvoiceLines";
            // 
            // colTrFeature
            // 
            this.colTrFeature.FieldName = "TrFeature";
            this.colTrFeature.Name = "colTrFeature";
            this.colTrFeature.Visible = true;
            this.colTrFeature.VisibleIndex = 16;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 17;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 18;
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            this.colLastUpdatedUserName.Visible = true;
            this.colLastUpdatedUserName.VisibleIndex = 19;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 20;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btn_saveLayout,
            this.bBI_formLogin,
            this.bBI_loadLayout});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1133, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btn_saveLayout
            // 
            this.btn_saveLayout.Caption = "Save Layout";
            this.btn_saveLayout.Id = 1;
            this.btn_saveLayout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_saveLayout.ImageOptions.SvgImage")));
            this.btn_saveLayout.Name = "btn_saveLayout";
            this.btn_saveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_saveLayout_ItemClick);
            // 
            // bBI_formLogin
            // 
            this.bBI_formLogin.Caption = "Login";
            this.bBI_formLogin.Id = 2;
            this.bBI_formLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_formLogin.ImageOptions.SvgImage")));
            this.bBI_formLogin.Name = "bBI_formLogin";
            this.bBI_formLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_formLogin_ItemClick);
            // 
            // bBI_loadLayout
            // 
            this.bBI_loadLayout.Caption = "Load Layout";
            this.bBI_loadLayout.Id = 3;
            this.bBI_loadLayout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bBI_loadLayout.ImageOptions.SvgImage")));
            this.bBI_loadLayout.Name = "bBI_loadLayout";
            this.bBI_loadLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBI_loadLayout_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_saveLayout);
            this.ribbonPageGroup1.ItemLinks.Add(this.bBI_loadLayout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bBI_formLogin);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 472);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1133, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // DefaultControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 496);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "DefaultControls";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcProductsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btn_saveLayout;
        private DevExpress.XtraBars.BarButtonItem bBI_formLogin;
        private DevExpress.XtraBars.BarButtonItem bBI_loadLayout;
        private System.Windows.Forms.BindingSource dcProductsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUsePos;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colWholesalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colUseInternet;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDcProductType;
        private DevExpress.XtraGrid.Columns.GridColumn colTrPrices;
        private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceLines;
        private DevExpress.XtraGrid.Columns.GridColumn colTrFeature;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
    }
}