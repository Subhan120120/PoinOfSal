
namespace PointOfSale
{
    partial class Form1
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
            this.trInvoiceLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colInvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelatedLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountCampaign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesPersonCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReturnQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrInvoiceHeader = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDcProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.trInvoiceLinesBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(36, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(741, 399);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceLineId,
            this.colInvoiceHeaderId,
            this.colRelatedLineId,
            this.colProductCode,
            this.colQty,
            this.colPrice,
            this.colAmount,
            this.colPosDiscount,
            this.colDiscountCampaign,
            this.colNetAmount,
            this.colVatRate,
            this.colLineDescription,
            this.colSalesPersonCode,
            this.colCurrencyCode,
            this.colExchangeRate,
            this.colReturnQty,
            this.colRemainingQty,
            this.colTrInvoiceHeader,
            this.colDcProduct,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colLastUpdatedUserName,
            this.colLastUpdatedDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // trInvoiceLinesBindingSource
            // 
            this.trInvoiceLinesBindingSource.DataSource = typeof(PointOfSale.Models.TrInvoiceLine);
            // 
            // colInvoiceLineId
            // 
            this.colInvoiceLineId.FieldName = "InvoiceLineId";
            this.colInvoiceLineId.Name = "colInvoiceLineId";
            this.colInvoiceLineId.Visible = true;
            this.colInvoiceLineId.VisibleIndex = 0;
            // 
            // colInvoiceHeaderId
            // 
            this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            this.colInvoiceHeaderId.Visible = true;
            this.colInvoiceHeaderId.VisibleIndex = 1;
            // 
            // colRelatedLineId
            // 
            this.colRelatedLineId.FieldName = "RelatedLineId";
            this.colRelatedLineId.Name = "colRelatedLineId";
            this.colRelatedLineId.Visible = true;
            this.colRelatedLineId.VisibleIndex = 2;
            // 
            // colProductCode
            // 
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 3;
            // 
            // colQty
            // 
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            // 
            // colPrice
            // 
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 5;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 6;
            // 
            // colPosDiscount
            // 
            this.colPosDiscount.FieldName = "PosDiscount";
            this.colPosDiscount.Name = "colPosDiscount";
            this.colPosDiscount.Visible = true;
            this.colPosDiscount.VisibleIndex = 7;
            // 
            // colDiscountCampaign
            // 
            this.colDiscountCampaign.FieldName = "DiscountCampaign";
            this.colDiscountCampaign.Name = "colDiscountCampaign";
            this.colDiscountCampaign.Visible = true;
            this.colDiscountCampaign.VisibleIndex = 8;
            // 
            // colNetAmount
            // 
            this.colNetAmount.FieldName = "NetAmount";
            this.colNetAmount.Name = "colNetAmount";
            this.colNetAmount.Visible = true;
            this.colNetAmount.VisibleIndex = 9;
            // 
            // colVatRate
            // 
            this.colVatRate.FieldName = "VatRate";
            this.colVatRate.Name = "colVatRate";
            this.colVatRate.Visible = true;
            this.colVatRate.VisibleIndex = 10;
            // 
            // colLineDescription
            // 
            this.colLineDescription.FieldName = "LineDescription";
            this.colLineDescription.Name = "colLineDescription";
            this.colLineDescription.Visible = true;
            this.colLineDescription.VisibleIndex = 11;
            // 
            // colSalesPersonCode
            // 
            this.colSalesPersonCode.FieldName = "SalesPersonCode";
            this.colSalesPersonCode.Name = "colSalesPersonCode";
            this.colSalesPersonCode.Visible = true;
            this.colSalesPersonCode.VisibleIndex = 12;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 13;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.FieldName = "ExchangeRate";
            this.colExchangeRate.Name = "colExchangeRate";
            this.colExchangeRate.Visible = true;
            this.colExchangeRate.VisibleIndex = 14;
            // 
            // colReturnQty
            // 
            this.colReturnQty.FieldName = "ReturnQty";
            this.colReturnQty.Name = "colReturnQty";
            this.colReturnQty.Visible = true;
            this.colReturnQty.VisibleIndex = 15;
            // 
            // colRemainingQty
            // 
            this.colRemainingQty.FieldName = "RemainingQty";
            this.colRemainingQty.Name = "colRemainingQty";
            this.colRemainingQty.Visible = true;
            this.colRemainingQty.VisibleIndex = 16;
            // 
            // colTrInvoiceHeader
            // 
            this.colTrInvoiceHeader.FieldName = "TrInvoiceHeader";
            this.colTrInvoiceHeader.Name = "colTrInvoiceHeader";
            this.colTrInvoiceHeader.Visible = true;
            this.colTrInvoiceHeader.VisibleIndex = 17;
            // 
            // colDcProduct
            // 
            this.colDcProduct.FieldName = "DcProduct";
            this.colDcProduct.Name = "colDcProduct";
            this.colDcProduct.Visible = true;
            this.colDcProduct.VisibleIndex = 18;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 19;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 20;
            // 
            // colLastUpdatedUserName
            // 
            this.colLastUpdatedUserName.FieldName = "LastUpdatedUserName";
            this.colLastUpdatedUserName.Name = "colLastUpdatedUserName";
            this.colLastUpdatedUserName.Visible = true;
            this.colLastUpdatedUserName.VisibleIndex = 21;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trInvoiceLinesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource trInvoiceLinesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colRelatedLineId;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountCampaign;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colVatRate;
        private DevExpress.XtraGrid.Columns.GridColumn colLineDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesPersonCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn colExchangeRate;
        private DevExpress.XtraGrid.Columns.GridColumn colReturnQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainingQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTrInvoiceHeader;
        private DevExpress.XtraGrid.Columns.GridColumn colDcProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
    }
}