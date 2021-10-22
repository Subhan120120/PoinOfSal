
using DevExpress.Utils;

namespace PointOfSale
{
    partial class FormCurrAccList
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
            this.gC_CurrAccList = new DevExpress.XtraGrid.GridControl();
            this.gV_CurrAccList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_CurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CurrAccTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_OfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_IdentityNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_BonusCardNum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).BeginInit();
            this.SuspendLayout();
            // 
            // gC_CurrAccList
            // 
            this.gC_CurrAccList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gC_CurrAccList.Location = new System.Drawing.Point(0, 0);
            this.gC_CurrAccList.MainView = this.gV_CurrAccList;
            this.gC_CurrAccList.Name = "gC_CurrAccList";
            this.gC_CurrAccList.Size = new System.Drawing.Size(841, 381);
            this.gC_CurrAccList.TabIndex = 0;
            this.gC_CurrAccList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gV_CurrAccList});
            // 
            // gV_CurrAccList
            // 
            this.gV_CurrAccList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_CurrAccCode,
            this.col_CurrAccTypeCode,
            this.col_OfficeCode,
            this.col_FirstName,
            this.col_LastName,
            this.col_IdentityNum,
            this.col_PhoneNum,
            this.col_Address,
            this.col_BonusCardNum});
            this.gV_CurrAccList.GridControl = this.gC_CurrAccList;
            this.gV_CurrAccList.Name = "gV_CurrAccList";
            this.gV_CurrAccList.DoubleClick += new System.EventHandler(this.gV_CurrAccList_DoubleClick);
            // 
            // col_CurrAccCode
            // 
            this.col_CurrAccCode.Caption = "Tədarikçi";
            this.col_CurrAccCode.FieldName = "CurrAccCode";
            this.col_CurrAccCode.Name = "col_CurrAccCode";
            this.col_CurrAccCode.Visible = true;
            this.col_CurrAccCode.VisibleIndex = 0;
            // 
            // col_CurrAccTypeCode
            // 
            this.col_CurrAccTypeCode.Caption = "Tədarikçi Tipi";
            this.col_CurrAccTypeCode.FieldName = "CurrAccTypeCode";
            this.col_CurrAccTypeCode.Name = "col_CurrAccTypeCode";
            this.col_CurrAccTypeCode.Visible = true;
            this.col_CurrAccTypeCode.VisibleIndex = 1;
            // 
            // col_OfficeCode
            // 
            this.col_OfficeCode.Caption = "Ofis Kodu";
            this.col_OfficeCode.FieldName = "OfficeCode";
            this.col_OfficeCode.Name = "col_OfficeCode";
            this.col_OfficeCode.Visible = true;
            this.col_OfficeCode.VisibleIndex = 2;
            // 
            // col_FirstName
            // 
            this.col_FirstName.Caption = "Adı";
            this.col_FirstName.FieldName = "FirstName";
            this.col_FirstName.Name = "col_FirstName";
            this.col_FirstName.Visible = true;
            this.col_FirstName.VisibleIndex = 3;
            // 
            // col_LastName
            // 
            this.col_LastName.Caption = "Soyadı";
            this.col_LastName.FieldName = "LastName";
            this.col_LastName.Name = "col_LastName";
            this.col_LastName.Visible = true;
            this.col_LastName.VisibleIndex = 4;
            // 
            // col_IdentityNum
            // 
            this.col_IdentityNum.Caption = "Ş.V. Nömrəsi";
            this.col_IdentityNum.FieldName = "IdentityNum";
            this.col_IdentityNum.Name = "col_IdentityNum";
            this.col_IdentityNum.Visible = true;
            this.col_IdentityNum.VisibleIndex = 5;
            // 
            // col_PhoneNum
            // 
            this.col_PhoneNum.Caption = "Telefon";
            this.col_PhoneNum.FieldName = "PhoneNum";
            this.col_PhoneNum.Name = "col_PhoneNum";
            this.col_PhoneNum.Visible = true;
            this.col_PhoneNum.VisibleIndex = 6;
            // 
            // col_Address
            // 
            this.col_Address.Caption = "Adres";
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            // 
            // col_BonusCardNum
            // 
            this.col_BonusCardNum.Caption = "Bonus Kartı";
            this.col_BonusCardNum.FieldName = "BonusCardNum";
            this.col_BonusCardNum.Name = "col_BonusCardNum";
            // 
            // FormCurrAccList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 381);
            this.Controls.Add(this.gC_CurrAccList);
            this.Name = "FormCurrAccList";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.FormCurrAccList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gC_CurrAccList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gV_CurrAccList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gC_CurrAccList;
        private DevExpress.XtraGrid.Views.Grid.GridView gV_CurrAccList;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_CurrAccTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_OfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn col_LastName;
        private DevExpress.XtraGrid.Columns.GridColumn col_IdentityNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_PhoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraGrid.Columns.GridColumn col_BonusCardNum;
    }
}