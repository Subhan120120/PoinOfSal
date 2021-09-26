
namespace PointOfSale
{
    partial class FormInvoiceHeaderList
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsReturn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomsDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcessCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(838, 418);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocumentNumber,
            this.colIsReturn,
            this.colDocumentDate,
            this.colDocumentTime,
            this.colDescription,
            this.colCurrAccCode,
            this.colOfficeCode,
            this.colStoreCode,
            this.colWarehouseCode,
            this.colCustomsDocumentNumber,
            this.colCreatedUserName,
            this.colCreatedDate,
            this.colInvoiceHeaderId,
            this.colProcessCode});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = "Faktura Nömrəsi";
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 0;
            // 
            // colIsReturn
            // 
            this.colIsReturn.Caption = "Geri Qaytarma";
            this.colIsReturn.FieldName = "IsReturn";
            this.colIsReturn.Name = "colIsReturn";
            this.colIsReturn.Visible = true;
            this.colIsReturn.VisibleIndex = 1;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.Caption = "Tarix";
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 2;
            // 
            // colDocumentTime
            // 
            this.colDocumentTime.Caption = "Saat";
            this.colDocumentTime.FieldName = "DocumentTime";
            this.colDocumentTime.Name = "colDocumentTime";
            this.colDocumentTime.Visible = true;
            this.colDocumentTime.VisibleIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Açıqlama";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.Caption = "Tədarikçi";
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 5;
            // 
            // colOfficeCode
            // 
            this.colOfficeCode.Caption = "Ofis Kodu";
            this.colOfficeCode.FieldName = "OfficeCode";
            this.colOfficeCode.Name = "colOfficeCode";
            this.colOfficeCode.Visible = true;
            this.colOfficeCode.VisibleIndex = 7;
            // 
            // colStoreCode
            // 
            this.colStoreCode.Caption = "Mağaza Kodu";
            this.colStoreCode.FieldName = "StoreCode";
            this.colStoreCode.Name = "colStoreCode";
            this.colStoreCode.Visible = true;
            this.colStoreCode.VisibleIndex = 6;
            // 
            // colWarehouseCode
            // 
            this.colWarehouseCode.Caption = "Depo Kodu";
            this.colWarehouseCode.FieldName = "WarehouseCode";
            this.colWarehouseCode.Name = "colWarehouseCode";
            this.colWarehouseCode.Visible = true;
            this.colWarehouseCode.VisibleIndex = 8;
            // 
            // colCustomsDocumentNumber
            // 
            this.colCustomsDocumentNumber.Caption = "Xüsusi Sənəd Nömrəsi";
            this.colCustomsDocumentNumber.FieldName = "CustomsDocumentNumber";
            this.colCustomsDocumentNumber.Name = "colCustomsDocumentNumber";
            this.colCustomsDocumentNumber.Visible = true;
            this.colCustomsDocumentNumber.VisibleIndex = 9;
            // 
            // colCreatedUserName
            // 
            this.colCreatedUserName.Caption = "Tərtib Edən İstifadəçi";
            this.colCreatedUserName.FieldName = "CreatedUserName";
            this.colCreatedUserName.Name = "colCreatedUserName";
            this.colCreatedUserName.Visible = true;
            this.colCreatedUserName.VisibleIndex = 10;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Yaradılma Tarixi";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 11;
            // 
            // colInvoiceHeaderId
            // 
            this.colInvoiceHeaderId.Caption = "InvoiceHeaderId";
            this.colInvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.colInvoiceHeaderId.Name = "colInvoiceHeaderId";
            // 
            // colProcessCode
            // 
            this.colProcessCode.Caption = "ProcessCode";
            this.colProcessCode.FieldName = "ProcessCode";
            this.colProcessCode.Name = "colProcessCode";
            this.colProcessCode.Visible = true;
            this.colProcessCode.VisibleIndex = 12;
            // 
            // FormInvoiceHeaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 418);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormInvoiceHeaderList";
            this.Text = "FormInvoiceHeaderList";
            this.Load += new System.EventHandler(this.FormInvoiceHeaderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReturn;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomsDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceHeaderId;
        private DevExpress.XtraGrid.Columns.GridColumn colProcessCode;
    }
}