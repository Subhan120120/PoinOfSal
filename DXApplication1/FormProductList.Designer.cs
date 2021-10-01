
using DevExpress.Utils;

namespace PointOfSale
{
    partial class FormProductList
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
            this.gC_ProductList = new DevExpress.XtraGrid.GridControl();
            this.gV_ProductList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_UsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PosDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gC_ProductList.DataMember = "DcProduct";
            this.gC_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_ProductList.Location = new System.Drawing.Point(0, 0);
            this.gC_ProductList.MainView = this.gV_ProductList;
            this.gC_ProductList.Name = "gridControl1";
            this.gC_ProductList.Size = new System.Drawing.Size(865, 415);
            this.gC_ProductList.TabIndex = 0;
            this.gC_ProductList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_ProductList});
            // 
            // gridView1
            // 
            this.gV_ProductList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ProductCode,
            this.col_Barcode,
            this.col_ProductTypeCode,
            this.col_UsePos,
            this.col_PromotionCode,
            this.col_PromotionCode2,
            this.col_TaxRate,
            this.col_IsDisabled,
            this.col_PosDiscountRate,
            this.col_RetailPrice,
            this.colProductDescription});
            this.gV_ProductList.GridControl = this.gC_ProductList;
            this.gV_ProductList.Name = "gridView1";
            this.gV_ProductList.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colProductCode
            // 
            this.col_ProductCode.FieldName = "ProductCode";
            this.col_ProductCode.Name = "colProductCode";
            this.col_ProductCode.Visible = true;
            this.col_ProductCode.VisibleIndex = 0;
            this.col_ProductCode.Width = 82;
            // 
            // colBarcode
            // 
            this.col_Barcode.FieldName = "Barcode";
            this.col_Barcode.Name = "colBarcode";
            this.col_Barcode.Visible = true;
            this.col_Barcode.VisibleIndex = 2;
            this.col_Barcode.Width = 56;
            // 
            // colProductTypeCode
            // 
            this.col_ProductTypeCode.FieldName = "ProductTypeCode";
            this.col_ProductTypeCode.Name = "colProductTypeCode";
            this.col_ProductTypeCode.Width = 93;
            // 
            // colUsePos
            // 
            this.col_UsePos.FieldName = "UsePos";
            this.col_UsePos.Name = "colUsePos";
            this.col_UsePos.Width = 50;
            // 
            // colPromotionCode
            // 
            this.col_PromotionCode.FieldName = "PromotionCode";
            this.col_PromotionCode.Name = "colPromotionCode";
            this.col_PromotionCode.Visible = true;
            this.col_PromotionCode.VisibleIndex = 5;
            this.col_PromotionCode.Width = 50;
            // 
            // colPromotionCode2
            // 
            this.col_PromotionCode2.FieldName = "PromotionCode2";
            this.col_PromotionCode2.Name = "colPromotionCode2";
            this.col_PromotionCode2.Visible = true;
            this.col_PromotionCode2.VisibleIndex = 6;
            this.col_PromotionCode2.Width = 50;
            // 
            // colTaxRate
            // 
            this.col_TaxRate.FieldName = "TaxRate";
            this.col_TaxRate.Name = "colTaxRate";
            this.col_TaxRate.Visible = true;
            this.col_TaxRate.VisibleIndex = 7;
            this.col_TaxRate.Width = 50;
            // 
            // colIsDisabled
            // 
            this.col_IsDisabled.FieldName = "IsDisabled";
            this.col_IsDisabled.Name = "colIsDisabled";
            this.col_IsDisabled.Width = 50;
            // 
            // colPosDiscountRate
            // 
            this.col_PosDiscountRate.FieldName = "PosDiscountRate";
            this.col_PosDiscountRate.Name = "colPosDiscountRate";
            this.col_PosDiscountRate.Visible = true;
            this.col_PosDiscountRate.VisibleIndex = 4;
            this.col_PosDiscountRate.Width = 53;
            // 
            // colRetailPrice
            // 
            this.col_RetailPrice.FieldName = "RetailPrice";
            this.col_RetailPrice.Name = "colRetailPrice";
            this.col_RetailPrice.Visible = true;
            this.col_RetailPrice.VisibleIndex = 3;
            this.col_RetailPrice.Width = 54;
            // 
            // colProductDescription
            // 
            this.colProductDescription.FieldName = "ProductDescription";
            this.colProductDescription.Name = "colProductDescription";
            this.colProductDescription.Visible = true;
            this.colProductDescription.VisibleIndex = 1;
            // 
            // FormProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 415);
            this.Controls.Add(this.gC_ProductList);
            this.Name = "FormProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormProductList";
            ((System.ComponentModel.ISupportInitialize)(this.gC_ProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_ProductList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_ProductList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_ProductList;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Barcode;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_UsePos;
        private DevExpress.XtraGrid.Columns.GridColumn col_PromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_PromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn col_TaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn col_IsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn col_PosDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn col_RetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDescription;
    }
}