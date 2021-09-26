
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCurrAccCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrAccTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOfficeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(841, 381);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCurrAccCode,
            this.colCurrAccTypeCode,
            this.colOfficeCode,
            this.colFirstName,
            this.colLastName,
            this.colIdentityNum,
            this.colPhoneNum});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colCurrAccCode
            // 
            this.colCurrAccCode.Caption = "Tədarikçi";
            this.colCurrAccCode.FieldName = "CurrAccCode";
            this.colCurrAccCode.Name = "colCurrAccCode";
            this.colCurrAccCode.Visible = true;
            this.colCurrAccCode.VisibleIndex = 0;
            // 
            // colCurrAccTypeCode
            // 
            this.colCurrAccTypeCode.Caption = "Tədarikçi Tipi";
            this.colCurrAccTypeCode.FieldName = "CurrAccTypeCode";
            this.colCurrAccTypeCode.Name = "colCurrAccTypeCode";
            this.colCurrAccTypeCode.Visible = true;
            this.colCurrAccTypeCode.VisibleIndex = 1;
            // 
            // colOfficeCode
            // 
            this.colOfficeCode.Caption = "Ofis Kodu";
            this.colOfficeCode.FieldName = "OfficeCode";
            this.colOfficeCode.Name = "colOfficeCode";
            this.colOfficeCode.Visible = true;
            this.colOfficeCode.VisibleIndex = 2;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Adı";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 3;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Soyadı";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 4;
            // 
            // colIdentityNum
            // 
            this.colIdentityNum.Caption = "Ş.V. Nömrəsi";
            this.colIdentityNum.FieldName = "IdentityNum";
            this.colIdentityNum.Name = "colIdentityNum";
            this.colIdentityNum.Visible = true;
            this.colIdentityNum.VisibleIndex = 5;
            // 
            // colPhoneNum
            // 
            this.colPhoneNum.Caption = "Telefon";
            this.colPhoneNum.FieldName = "PhoneNum";
            this.colPhoneNum.Name = "colPhoneNum";
            this.colPhoneNum.Visible = true;
            this.colPhoneNum.VisibleIndex = 6;
            // 
            // FormCurrAccList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 381);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormCurrAccList";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.FormCurrAccList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrAccTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOfficeCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityNum;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNum;
    }
}