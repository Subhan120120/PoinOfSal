
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
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsePos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPromotionCode2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDisabled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetailPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "DcProduct";
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(674, 415);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductCode,
            this.colBarcode,
            this.colProductTypeCode,
            this.colUsePos,
            this.colPromotionCode,
            this.colPromotionCode2,
            this.colTaxRate,
            this.colIsDisabled,
            this.colPosDiscountRate,
            this.colRetailPrice,
            this.colProductDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 0;
            this.colProductCode.Width = 82;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 2;
            this.colBarcode.Width = 56;
            // 
            // colProductTypeCode
            // 
            this.colProductTypeCode.FieldName = "ProductTypeCode";
            this.colProductTypeCode.Name = "colProductTypeCode";
            this.colProductTypeCode.Width = 93;
            // 
            // colUsePos
            // 
            this.colUsePos.FieldName = "UsePos";
            this.colUsePos.Name = "colUsePos";
            this.colUsePos.Width = 50;
            // 
            // colPromotionCode
            // 
            this.colPromotionCode.FieldName = "PromotionCode";
            this.colPromotionCode.Name = "colPromotionCode";
            this.colPromotionCode.Visible = true;
            this.colPromotionCode.VisibleIndex = 5;
            this.colPromotionCode.Width = 50;
            // 
            // colPromotionCode2
            // 
            this.colPromotionCode2.FieldName = "PromotionCode2";
            this.colPromotionCode2.Name = "colPromotionCode2";
            this.colPromotionCode2.Visible = true;
            this.colPromotionCode2.VisibleIndex = 6;
            this.colPromotionCode2.Width = 50;
            // 
            // colTaxRate
            // 
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 7;
            this.colTaxRate.Width = 50;
            // 
            // colIsDisabled
            // 
            this.colIsDisabled.FieldName = "IsDisabled";
            this.colIsDisabled.Name = "colIsDisabled";
            this.colIsDisabled.Width = 50;
            // 
            // colPosDiscountRate
            // 
            this.colPosDiscountRate.FieldName = "PosDiscountRate";
            this.colPosDiscountRate.Name = "colPosDiscountRate";
            this.colPosDiscountRate.Visible = true;
            this.colPosDiscountRate.VisibleIndex = 4;
            this.colPosDiscountRate.Width = 53;
            // 
            // colRetailPrice
            // 
            this.colRetailPrice.FieldName = "RetailPrice";
            this.colRetailPrice.Name = "colRetailPrice";
            this.colRetailPrice.Visible = true;
            this.colRetailPrice.VisibleIndex = 3;
            this.colRetailPrice.Width = 54;
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
            this.ClientSize = new System.Drawing.Size(674, 415);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormProductList";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colProductTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUsePos;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPromotionCode2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDisabled;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn colRetailPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colProductDescription;
    }
}