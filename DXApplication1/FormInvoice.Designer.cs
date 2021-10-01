
using System;

namespace PointOfSale
{
    partial class FormInvoice
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RibbonControl_Root = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bBI_Save = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_SaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_SaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Reset = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.bBI_Close = new DevExpress.XtraBars.BarButtonItem();
            this.RibbonPage_Invoice = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RibbonPageGroup_Invoice = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.lookUpEdit_WarehouseCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lC_Root = new DevExpress.XtraLayout.LayoutControl();
            this.gC_InvoiceLine = new DevExpress.XtraGrid.GridControl();
            this.TrInvoiceLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subDataSet = new PointOfSale.subDataSet();
            this.gV_InvoiceLine = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_InvoiceLineId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_InvoiceHeaderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoBtnEdit_ProductCode = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.col_Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PosDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NetAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LineDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnEdit_DocNum = new DevExpress.XtraEditors.ButtonEdit();
            this.checkEdit_IsReturn = new DevExpress.XtraEditors.CheckEdit();
            this.dateEdit_DocDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_DocTime = new DevExpress.XtraEditors.TimeEdit();
            this.txtEdit_InvoiceCustomNum = new DevExpress.XtraEditors.TextEdit();
            this.btnEdit_CurrAccCode = new DevExpress.XtraEditors.ButtonEdit();
            this.memoEdit_InvoiceDesc = new DevExpress.XtraEditors.MemoEdit();
            this.lookUpEdit_OfficeCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEdit_StoreCode = new DevExpress.XtraEditors.LookUpEdit();
            this.lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_DocDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_DocTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_InvoiceLine = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_OfficeCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_StoreCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_WarehouseCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CurrAccCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_InvoiceDesc = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_DocNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_CustomDocNum = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_IsReturn = new DevExpress.XtraLayout.LayoutControlItem();
            this.TrInvoiceLineTableAdapter = new PointOfSale.subDataSetTableAdapters.TrInvoiceLineTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl_Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_WarehouseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).BeginInit();
            this.lC_Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrInvoiceLineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_IsReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_InvoiceCustomNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_InvoiceDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_OfficeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_StoreCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_InvoiceLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_OfficeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_StoreCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CurrAccCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_InvoiceDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomDocNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_IsReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // RibbonControl_Root
            // 
            this.RibbonControl_Root.ExpandCollapseItem.Id = 0;
            this.RibbonControl_Root.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.RibbonControl_Root.ExpandCollapseItem,
            this.bBI_Save,
            this.bBI_SaveAndClose,
            this.bBI_SaveAndNew,
            this.bBI_Reset,
            this.bBI_Delete,
            this.bBI_Close});
            this.RibbonControl_Root.Location = new System.Drawing.Point(0, 0);
            this.RibbonControl_Root.MaxItemId = 10;
            this.RibbonControl_Root.Name = "RibbonControl_Root";
            this.RibbonControl_Root.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.RibbonPage_Invoice});
            this.RibbonControl_Root.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            // 
            // 
            // 
            this.RibbonControl_Root.SearchEditItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.RibbonControl_Root.SearchEditItem.EditWidth = 150;
            this.RibbonControl_Root.SearchEditItem.Id = -5000;
            this.RibbonControl_Root.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.RibbonControl_Root.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.RibbonControl_Root.Size = new System.Drawing.Size(903, 158);
            this.RibbonControl_Root.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bBI_Save
            // 
            this.bBI_Save.Caption = "Save";
            this.bBI_Save.Id = 2;
            this.bBI_Save.ImageOptions.ImageUri.Uri = "Save";
            this.bBI_Save.Name = "bBI_Save";
            // 
            // bBI_SaveAndClose
            // 
            this.bBI_SaveAndClose.Caption = "Save And Close";
            this.bBI_SaveAndClose.Id = 3;
            this.bBI_SaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bBI_SaveAndClose.Name = "bBI_SaveAndClose";
            // 
            // bBI_SaveAndNew
            // 
            this.bBI_SaveAndNew.Caption = "Save And New";
            this.bBI_SaveAndNew.Id = 4;
            this.bBI_SaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bBI_SaveAndNew.Name = "bBI_SaveAndNew";
            // 
            // bBI_Reset
            // 
            this.bBI_Reset.Caption = "Reset Changes";
            this.bBI_Reset.Id = 5;
            this.bBI_Reset.ImageOptions.ImageUri.Uri = "Reset";
            this.bBI_Reset.Name = "bBI_Reset";
            // 
            // bBI_Delete
            // 
            this.bBI_Delete.Caption = "Delete";
            this.bBI_Delete.Id = 6;
            this.bBI_Delete.ImageOptions.ImageUri.Uri = "Delete";
            this.bBI_Delete.Name = "bBI_Delete";
            // 
            // bBI_Close
            // 
            this.bBI_Close.Caption = "Close";
            this.bBI_Close.Id = 7;
            this.bBI_Close.ImageOptions.ImageUri.Uri = "Close";
            this.bBI_Close.Name = "bBI_Close";
            // 
            // RibbonPage_Invoice
            // 
            this.RibbonPage_Invoice.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RibbonPageGroup_Invoice});
            this.RibbonPage_Invoice.MergeOrder = 15;
            this.RibbonPage_Invoice.Name = "RibbonPage_Invoice";
            this.RibbonPage_Invoice.Text = "Faktura";
            // 
            // RibbonPageGroup_Invoice
            // 
            this.RibbonPageGroup_Invoice.AllowTextClipping = false;
            this.RibbonPageGroup_Invoice.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_Save);
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_SaveAndClose);
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_SaveAndNew);
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_Reset);
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_Delete);
            this.RibbonPageGroup_Invoice.ItemLinks.Add(this.bBI_Close);
            this.RibbonPageGroup_Invoice.Name = "RibbonPageGroup_Invoice";
            this.RibbonPageGroup_Invoice.Text = "Tasks";
            // 
            // lookUpEdit_WarehouseCode
            // 
            this.lookUpEdit_WarehouseCode.Location = new System.Drawing.Point(550, 84);
            this.lookUpEdit_WarehouseCode.MenuManager = this.RibbonControl_Root;
            this.lookUpEdit_WarehouseCode.Name = "lookUpEdit_WarehouseCode";
            this.lookUpEdit_WarehouseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_WarehouseCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseCode", "Depo Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WarehouseDesc", "Depo Adı")});
            this.lookUpEdit_WarehouseCode.Properties.DisplayMember = "WarehouseDesc";
            this.lookUpEdit_WarehouseCode.Properties.NullText = "";
            this.lookUpEdit_WarehouseCode.Properties.ShowHeader = false;
            this.lookUpEdit_WarehouseCode.Properties.ValueMember = "WarehouseCode";
            this.lookUpEdit_WarehouseCode.Size = new System.Drawing.Size(341, 20);
            this.lookUpEdit_WarehouseCode.StyleController = this.lC_Root;
            this.lookUpEdit_WarehouseCode.TabIndex = 10;
            // 
            // lC_Root
            // 
            this.lC_Root.Controls.Add(this.gC_InvoiceLine);
            this.lC_Root.Controls.Add(this.btnEdit_DocNum);
            this.lC_Root.Controls.Add(this.checkEdit_IsReturn);
            this.lC_Root.Controls.Add(this.dateEdit_DocDate);
            this.lC_Root.Controls.Add(this.dateEdit_DocTime);
            this.lC_Root.Controls.Add(this.txtEdit_InvoiceCustomNum);
            this.lC_Root.Controls.Add(this.btnEdit_CurrAccCode);
            this.lC_Root.Controls.Add(this.memoEdit_InvoiceDesc);
            this.lC_Root.Controls.Add(this.lookUpEdit_OfficeCode);
            this.lC_Root.Controls.Add(this.lookUpEdit_StoreCode);
            this.lC_Root.Controls.Add(this.lookUpEdit_WarehouseCode);
            this.lC_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lC_Root.Location = new System.Drawing.Point(0, 158);
            this.lC_Root.Name = "lC_Root";
            this.lC_Root.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1172, 348, 650, 400);
            this.lC_Root.Root = this.lCG_Root;
            this.lC_Root.Size = new System.Drawing.Size(903, 423);
            this.lC_Root.TabIndex = 2;
            this.lC_Root.Text = "layoutControl1";
            // 
            // gC_InvoiceLine
            // 
            this.gC_InvoiceLine.DataSource = this.TrInvoiceLineBindingSource;
            this.gC_InvoiceLine.Location = new System.Drawing.Point(12, 132);
            this.gC_InvoiceLine.MainView = this.gV_InvoiceLine;
            this.gC_InvoiceLine.MenuManager = this.RibbonControl_Root;
            this.gC_InvoiceLine.Name = "gC_InvoiceLine";
            this.gC_InvoiceLine.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoBtnEdit_ProductCode});
            this.gC_InvoiceLine.Size = new System.Drawing.Size(879, 279);
            this.gC_InvoiceLine.TabIndex = 12;
            this.gC_InvoiceLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_InvoiceLine});
            // 
            // TrInvoiceLineBindingSource
            // 
            this.TrInvoiceLineBindingSource.DataMember = "TrInvoiceLine";
            this.TrInvoiceLineBindingSource.DataSource = this.subDataSet;
            // 
            // subDataSet
            // 
            this.subDataSet.DataSetName = "subDataSet";
            this.subDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gV_InvoiceLine
            // 
            this.gV_InvoiceLine.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_InvoiceLineId,
            this.col_InvoiceHeaderId,
            this.col_ProductCode,
            this.col_Qty,
            this.col_Price,
            this.col_Amount,
            this.col_PosDiscount,
            this.col_NetAmount,
            this.col_LineDesc});
            this.gV_InvoiceLine.GridControl = this.gC_InvoiceLine;
            this.gV_InvoiceLine.Name = "gV_InvoiceLine";
            this.gV_InvoiceLine.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gV_InvoiceLine.OptionsView.ShowFooter = true;
            this.gV_InvoiceLine.OptionsView.ShowGroupPanel = false;
            this.gV_InvoiceLine.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gV_InvoiceLine.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gV_InvoiceLine.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gV_InvoiceLine.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gV_InvoiceLine.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // col_InvoiceLineId
            // 
            this.col_InvoiceLineId.Caption = "InvoiceLineId";
            this.col_InvoiceLineId.FieldName = "InvoiceLineId";
            this.col_InvoiceLineId.Name = "col_InvoiceLineId";
            this.col_InvoiceLineId.OptionsEditForm.StartNewRow = true;
            this.col_InvoiceLineId.Visible = true;
            this.col_InvoiceLineId.VisibleIndex = 7;
            // 
            // col_InvoiceHeaderId
            // 
            this.col_InvoiceHeaderId.Caption = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.FieldName = "InvoiceHeaderId";
            this.col_InvoiceHeaderId.Name = "col_InvoiceHeaderId";
            this.col_InvoiceHeaderId.Visible = true;
            this.col_InvoiceHeaderId.VisibleIndex = 8;
            // 
            // col_ProductCode
            // 
            this.col_ProductCode.Caption = "Məhsul";
            this.col_ProductCode.ColumnEdit = this.repoBtnEdit_ProductCode;
            this.col_ProductCode.FieldName = "ProductCode";
            this.col_ProductCode.Name = "col_ProductCode";
            this.col_ProductCode.Visible = true;
            this.col_ProductCode.VisibleIndex = 0;
            // 
            // repoBtnEdit_ProductCode
            // 
            this.repoBtnEdit_ProductCode.AutoHeight = false;
            this.repoBtnEdit_ProductCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repoBtnEdit_ProductCode.Name = "repoBtnEdit_ProductCode";
            this.repoBtnEdit_ProductCode.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repoItemButtonEditProductCode_ButtonPressed);
            // 
            // col_Qty
            // 
            this.col_Qty.Caption = "Say";
            this.col_Qty.FieldName = "Qty";
            this.col_Qty.Name = "col_Qty";
            this.col_Qty.Visible = true;
            this.col_Qty.VisibleIndex = 1;
            // 
            // col_Price
            // 
            this.col_Price.Caption = "Qiymət";
            this.col_Price.FieldName = "Price";
            this.col_Price.Name = "col_Price";
            this.col_Price.Visible = true;
            this.col_Price.VisibleIndex = 2;
            // 
            // col_Amount
            // 
            this.col_Amount.Caption = "Tutar";
            this.col_Amount.FieldName = "Amount";
            this.col_Amount.Name = "col_Amount";
            this.col_Amount.OptionsColumn.AllowEdit = false;
            this.col_Amount.Visible = true;
            this.col_Amount.VisibleIndex = 3;
            // 
            // col_PosDiscount
            // 
            this.col_PosDiscount.Caption = "Endirim";
            this.col_PosDiscount.FieldName = "PosDiscount";
            this.col_PosDiscount.Name = "col_PosDiscount";
            this.col_PosDiscount.Visible = true;
            this.col_PosDiscount.VisibleIndex = 4;
            // 
            // col_NetAmount
            // 
            this.col_NetAmount.Caption = "Net Tutar";
            this.col_NetAmount.FieldName = "NetAmount";
            this.col_NetAmount.Name = "col_NetAmount";
            this.col_NetAmount.Visible = true;
            this.col_NetAmount.VisibleIndex = 5;
            // 
            // col_LineDesc
            // 
            this.col_LineDesc.Caption = "Qeyd";
            this.col_LineDesc.FieldName = "LineDescription";
            this.col_LineDesc.Name = "col_LineDesc";
            this.col_LineDesc.Visible = true;
            this.col_LineDesc.VisibleIndex = 6;
            // 
            // btnEdit_DocNum
            // 
            this.btnEdit_DocNum.Location = new System.Drawing.Point(126, 12);
            this.btnEdit_DocNum.MenuManager = this.RibbonControl_Root;
            this.btnEdit_DocNum.Name = "btnEdit_DocNum";
            this.btnEdit_DocNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_DocNum.Size = new System.Drawing.Size(306, 20);
            this.btnEdit_DocNum.StyleController = this.lC_Root;
            this.btnEdit_DocNum.TabIndex = 4;
            this.btnEdit_DocNum.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditDocNum_ButtonPressed);
            // 
            // checkEdit_IsReturn
            // 
            this.checkEdit_IsReturn.Location = new System.Drawing.Point(12, 36);
            this.checkEdit_IsReturn.MenuManager = this.RibbonControl_Root;
            this.checkEdit_IsReturn.Name = "checkEdit_IsReturn";
            this.checkEdit_IsReturn.Properties.Caption = "Geri Qaytarma";
            this.checkEdit_IsReturn.Size = new System.Drawing.Size(420, 20);
            this.checkEdit_IsReturn.StyleController = this.lC_Root;
            this.checkEdit_IsReturn.TabIndex = 5;
            // 
            // dateEdit_DocDate
            // 
            this.dateEdit_DocDate.EditValue = new System.DateTime(2021, 9, 20, 9, 43, 19, 29);
            this.dateEdit_DocDate.Location = new System.Drawing.Point(126, 84);
            this.dateEdit_DocDate.MenuManager = this.RibbonControl_Root;
            this.dateEdit_DocDate.Name = "dateEdit_DocDate";
            this.dateEdit_DocDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocDate.Size = new System.Drawing.Size(306, 20);
            this.dateEdit_DocDate.StyleController = this.lC_Root;
            this.dateEdit_DocDate.TabIndex = 6;
            // 
            // dateEdit_DocTime
            // 
            this.dateEdit_DocTime.EditValue = new System.DateTime(2021, 9, 20, 9, 43, 19, 34);
            this.dateEdit_DocTime.Location = new System.Drawing.Point(126, 108);
            this.dateEdit_DocTime.MenuManager = this.RibbonControl_Root;
            this.dateEdit_DocTime.Name = "dateEdit_DocTime";
            this.dateEdit_DocTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DocTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit_DocTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateEdit_DocTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.dateEdit_DocTime.Size = new System.Drawing.Size(306, 20);
            this.dateEdit_DocTime.StyleController = this.lC_Root;
            this.dateEdit_DocTime.TabIndex = 7;
            // 
            // txtEdit_InvoiceCustomNum
            // 
            this.txtEdit_InvoiceCustomNum.Location = new System.Drawing.Point(126, 60);
            this.txtEdit_InvoiceCustomNum.MenuManager = this.RibbonControl_Root;
            this.txtEdit_InvoiceCustomNum.Name = "txtEdit_InvoiceCustomNum";
            this.txtEdit_InvoiceCustomNum.Size = new System.Drawing.Size(306, 20);
            this.txtEdit_InvoiceCustomNum.StyleController = this.lC_Root;
            this.txtEdit_InvoiceCustomNum.TabIndex = 11;
            // 
            // btnEdit_CurrAccCode
            // 
            this.btnEdit_CurrAccCode.Location = new System.Drawing.Point(550, 12);
            this.btnEdit_CurrAccCode.MenuManager = this.RibbonControl_Root;
            this.btnEdit_CurrAccCode.Name = "btnEdit_CurrAccCode";
            this.btnEdit_CurrAccCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_CurrAccCode.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)(((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorFocused) 
            | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.btnEdit_CurrAccCode.Size = new System.Drawing.Size(341, 20);
            this.btnEdit_CurrAccCode.StyleController = this.lC_Root;
            this.btnEdit_CurrAccCode.TabIndex = 14;
            this.btnEdit_CurrAccCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditCurrAccCode_ButtonClick);
            // 
            // memoEdit_InvoiceDesc
            // 
            this.memoEdit_InvoiceDesc.Location = new System.Drawing.Point(550, 108);
            this.memoEdit_InvoiceDesc.MenuManager = this.RibbonControl_Root;
            this.memoEdit_InvoiceDesc.Name = "memoEdit_InvoiceDesc";
            this.memoEdit_InvoiceDesc.Size = new System.Drawing.Size(341, 20);
            this.memoEdit_InvoiceDesc.StyleController = this.lC_Root;
            this.memoEdit_InvoiceDesc.TabIndex = 13;
            // 
            // lookUpEdit_OfficeCode
            // 
            this.lookUpEdit_OfficeCode.Location = new System.Drawing.Point(550, 36);
            this.lookUpEdit_OfficeCode.MenuManager = this.RibbonControl_Root;
            this.lookUpEdit_OfficeCode.Name = "lookUpEdit_OfficeCode";
            this.lookUpEdit_OfficeCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_OfficeCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OfficeCode", "Ofis kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OfficeDesc", "Ofis Adı")});
            this.lookUpEdit_OfficeCode.Properties.DisplayMember = "OfficeDesc";
            this.lookUpEdit_OfficeCode.Properties.NullText = "";
            this.lookUpEdit_OfficeCode.Properties.ShowHeader = false;
            this.lookUpEdit_OfficeCode.Properties.ValueMember = "OfficeCode";
            this.lookUpEdit_OfficeCode.Size = new System.Drawing.Size(341, 20);
            this.lookUpEdit_OfficeCode.StyleController = this.lC_Root;
            this.lookUpEdit_OfficeCode.TabIndex = 8;
            // 
            // lookUpEdit_StoreCode
            // 
            this.lookUpEdit_StoreCode.Location = new System.Drawing.Point(550, 60);
            this.lookUpEdit_StoreCode.MenuManager = this.RibbonControl_Root;
            this.lookUpEdit_StoreCode.Name = "lookUpEdit_StoreCode";
            this.lookUpEdit_StoreCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit_StoreCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreCode", "Mağaza Kodu"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StoreDesc", "Mağaza Adı")});
            this.lookUpEdit_StoreCode.Properties.DisplayMember = "StoreDesc";
            this.lookUpEdit_StoreCode.Properties.NullText = "";
            this.lookUpEdit_StoreCode.Properties.ShowHeader = false;
            this.lookUpEdit_StoreCode.Properties.ValueMember = "StoreCode";
            this.lookUpEdit_StoreCode.Size = new System.Drawing.Size(341, 20);
            this.lookUpEdit_StoreCode.StyleController = this.lC_Root;
            this.lookUpEdit_StoreCode.TabIndex = 9;
            // 
            // lCG_Root
            // 
            this.lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lCG_Root.GroupBordersVisible = false;
            this.lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_DocDate,
            this.lCI_DocTime,
            this.lCI_InvoiceLine,
            this.lCI_OfficeCode,
            this.lCI_StoreCode,
            this.lCI_WarehouseCode,
            this.lCI_CurrAccCode,
            this.lCI_InvoiceDesc,
            this.lCI_DocNum,
            this.lCI_CustomDocNum,
            this.lCI_IsReturn});
            this.lCG_Root.Name = "lCG_Root";
            this.lCG_Root.Size = new System.Drawing.Size(903, 423);
            this.lCG_Root.TextVisible = false;
            // 
            // lCI_DocDate
            // 
            this.lCI_DocDate.Control = this.dateEdit_DocDate;
            this.lCI_DocDate.Location = new System.Drawing.Point(0, 72);
            this.lCI_DocDate.Name = "lCI_DocDate";
            this.lCI_DocDate.Size = new System.Drawing.Size(424, 24);
            this.lCI_DocDate.Text = "Faktura Tarixi";
            this.lCI_DocDate.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_DocTime
            // 
            this.lCI_DocTime.Control = this.dateEdit_DocTime;
            this.lCI_DocTime.Location = new System.Drawing.Point(0, 96);
            this.lCI_DocTime.Name = "lCI_DocTime";
            this.lCI_DocTime.Size = new System.Drawing.Size(424, 24);
            this.lCI_DocTime.Text = "Faktura Vaxtı";
            this.lCI_DocTime.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_InvoiceLine
            // 
            this.lCI_InvoiceLine.Control = this.gC_InvoiceLine;
            this.lCI_InvoiceLine.Location = new System.Drawing.Point(0, 120);
            this.lCI_InvoiceLine.Name = "lCI_InvoiceLine";
            this.lCI_InvoiceLine.Size = new System.Drawing.Size(883, 283);
            this.lCI_InvoiceLine.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_InvoiceLine.TextVisible = false;
            // 
            // lCI_OfficeCode
            // 
            this.lCI_OfficeCode.Control = this.lookUpEdit_OfficeCode;
            this.lCI_OfficeCode.Location = new System.Drawing.Point(424, 24);
            this.lCI_OfficeCode.Name = "lCI_OfficeCode";
            this.lCI_OfficeCode.Size = new System.Drawing.Size(459, 24);
            this.lCI_OfficeCode.Text = "Ofis Kodu";
            this.lCI_OfficeCode.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_StoreCode
            // 
            this.lCI_StoreCode.Control = this.lookUpEdit_StoreCode;
            this.lCI_StoreCode.Location = new System.Drawing.Point(424, 48);
            this.lCI_StoreCode.Name = "lCI_StoreCode";
            this.lCI_StoreCode.Size = new System.Drawing.Size(459, 24);
            this.lCI_StoreCode.Text = "Mağaza Kodu";
            this.lCI_StoreCode.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_WarehouseCode
            // 
            this.lCI_WarehouseCode.Control = this.lookUpEdit_WarehouseCode;
            this.lCI_WarehouseCode.Location = new System.Drawing.Point(424, 72);
            this.lCI_WarehouseCode.Name = "lCI_WarehouseCode";
            this.lCI_WarehouseCode.Size = new System.Drawing.Size(459, 24);
            this.lCI_WarehouseCode.Text = "Depo Kodu";
            this.lCI_WarehouseCode.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_CurrAccCode
            // 
            this.lCI_CurrAccCode.Control = this.btnEdit_CurrAccCode;
            this.lCI_CurrAccCode.Location = new System.Drawing.Point(424, 0);
            this.lCI_CurrAccCode.Name = "lCI_CurrAccCode";
            this.lCI_CurrAccCode.Size = new System.Drawing.Size(459, 24);
            this.lCI_CurrAccCode.Text = "Tədarikçi";
            this.lCI_CurrAccCode.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_InvoiceDesc
            // 
            this.lCI_InvoiceDesc.Control = this.memoEdit_InvoiceDesc;
            this.lCI_InvoiceDesc.Location = new System.Drawing.Point(424, 96);
            this.lCI_InvoiceDesc.Name = "lCI_InvoiceDesc";
            this.lCI_InvoiceDesc.Size = new System.Drawing.Size(459, 24);
            this.lCI_InvoiceDesc.Text = "Açıqlama";
            this.lCI_InvoiceDesc.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_DocNum
            // 
            this.lCI_DocNum.Control = this.btnEdit_DocNum;
            this.lCI_DocNum.Location = new System.Drawing.Point(0, 0);
            this.lCI_DocNum.Name = "lCI_DocNum";
            this.lCI_DocNum.Size = new System.Drawing.Size(424, 24);
            this.lCI_DocNum.Text = "Faktura";
            this.lCI_DocNum.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_CustomDocNum
            // 
            this.lCI_CustomDocNum.Control = this.txtEdit_InvoiceCustomNum;
            this.lCI_CustomDocNum.Location = new System.Drawing.Point(0, 48);
            this.lCI_CustomDocNum.Name = "lCI_CustomDocNum";
            this.lCI_CustomDocNum.Size = new System.Drawing.Size(424, 24);
            this.lCI_CustomDocNum.Text = "Xüsusi Faktura Nömrəsi";
            this.lCI_CustomDocNum.TextSize = new System.Drawing.Size(111, 13);
            // 
            // lCI_IsReturn
            // 
            this.lCI_IsReturn.Control = this.checkEdit_IsReturn;
            this.lCI_IsReturn.Location = new System.Drawing.Point(0, 24);
            this.lCI_IsReturn.Name = "lCI_IsReturn";
            this.lCI_IsReturn.Size = new System.Drawing.Size(424, 24);
            this.lCI_IsReturn.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_IsReturn.TextVisible = false;
            // 
            // TrInvoiceLineTableAdapter
            // 
            this.TrInvoiceLineTableAdapter.ClearBeforeFill = true;
            // 
            // FormInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(903, 581);
            this.Controls.Add(this.lC_Root);
            this.Controls.Add(this.RibbonControl_Root);
            this.Name = "FormInvoice";
            this.Ribbon = this.RibbonControl_Root;
            this.Text = "Faktura";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RibbonControl_Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_WarehouseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).EndInit();
            this.lC_Root.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gC_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrInvoiceLineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoBtnEdit_ProductCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_DocNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_IsReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DocTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_InvoiceCustomNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_CurrAccCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_InvoiceDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_OfficeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_StoreCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_InvoiceLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_OfficeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_StoreCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CurrAccCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_InvoiceDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_DocNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_CustomDocNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_IsReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl RibbonControl_Root;
        private DevExpress.XtraBars.Ribbon.RibbonPage RibbonPage_Invoice;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RibbonPageGroup_Invoice;
        private DevExpress.XtraBars.BarButtonItem bBI_Save;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bBI_SaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bBI_Reset;
        private DevExpress.XtraBars.BarButtonItem bBI_Delete;
        private DevExpress.XtraBars.BarButtonItem bBI_Close;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_WarehouseCode;
        private DevExpress.XtraLayout.LayoutControl lC_Root;
        private DevExpress.XtraGrid.GridControl gC_InvoiceLine;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_InvoiceLine;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceLineId;
        private DevExpress.XtraGrid.Columns.GridColumn col_InvoiceHeaderId;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_DocNum;
        private DevExpress.XtraEditors.CheckEdit checkEdit_IsReturn;
        private DevExpress.XtraEditors.DateEdit dateEdit_DocDate;
        private DevExpress.XtraEditors.TimeEdit dateEdit_DocTime;
        private DevExpress.XtraEditors.TextEdit txtEdit_InvoiceCustomNum;
        private DevExpress.XtraEditors.ButtonEdit btnEdit_CurrAccCode;
        private DevExpress.XtraEditors.MemoEdit memoEdit_InvoiceDesc;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_OfficeCode;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit_StoreCode;
        private DevExpress.XtraLayout.LayoutControlGroup lCG_Root;
        private DevExpress.XtraLayout.LayoutControlItem lCI_DocDate;
        private DevExpress.XtraLayout.LayoutControlItem lCI_DocTime;
        private DevExpress.XtraLayout.LayoutControlItem lCI_InvoiceLine;
        private DevExpress.XtraLayout.LayoutControlItem lCI_OfficeCode;
        private DevExpress.XtraLayout.LayoutControlItem lCI_StoreCode;
        private DevExpress.XtraLayout.LayoutControlItem lCI_WarehouseCode;
        private DevExpress.XtraLayout.LayoutControlItem lCI_CurrAccCode;
        private DevExpress.XtraLayout.LayoutControlItem lCI_InvoiceDesc;
        private DevExpress.XtraLayout.LayoutControlItem lCI_DocNum;
        private DevExpress.XtraLayout.LayoutControlItem lCI_CustomDocNum;
        private DevExpress.XtraLayout.LayoutControlItem lCI_IsReturn;
        private subDataSet subDataSet;
        private System.Windows.Forms.BindingSource TrInvoiceLineBindingSource;
        private subDataSetTableAdapters.TrInvoiceLineTableAdapter TrInvoiceLineTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn col_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_Qty;
        private DevExpress.XtraGrid.Columns.GridColumn col_Price;
        private DevExpress.XtraGrid.Columns.GridColumn col_Amount;
        private DevExpress.XtraGrid.Columns.GridColumn col_PosDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn col_NetAmount;
        private DevExpress.XtraGrid.Columns.GridColumn col_LineDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repoBtnEdit_ProductCode;
    }
}