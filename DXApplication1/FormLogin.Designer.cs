
namespace PointOfSale
{
    partial class FormLogin
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PointOfSale.SplashScreenStartup), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btn_ERP = new DevExpress.XtraEditors.SimpleButton();
            this.lC_Root = new DevExpress.XtraLayout.LayoutControl();
            this.btn_POS = new DevExpress.XtraEditors.SimpleButton();
            this.txtEdit_UserName = new DevExpress.XtraEditors.TextEdit();
            this.txtEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit_RemindMe = new DevExpress.XtraEditors.CheckEdit();
            this.lCG_Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lCI_ERP = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_POS = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_UserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_Password = new DevExpress.XtraLayout.LayoutControlItem();
            this.lCI_RemindMe = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).BeginInit();
            this.lC_Root.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_RemindMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ERP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_POS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_RemindMe)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // btn_ERP
            // 
            this.btn_ERP.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_ERP.Appearance.Options.UseFont = true;
            this.btn_ERP.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_ERP.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_ERP.ImageOptions.SvgImage")));
            this.btn_ERP.Location = new System.Drawing.Point(131, 84);
            this.btn_ERP.Name = "btn_ERP";
            this.btn_ERP.Size = new System.Drawing.Size(115, 99);
            this.btn_ERP.StyleController = this.lC_Root;
            this.btn_ERP.TabIndex = 0;
            this.btn_ERP.Text = "Arxa Ofis";
            this.btn_ERP.Click += new System.EventHandler(this.btn_ERP_Click);
            // 
            // lC_Root
            // 
            this.lC_Root.Controls.Add(this.btn_POS);
            this.lC_Root.Controls.Add(this.btn_ERP);
            this.lC_Root.Controls.Add(this.txtEdit_UserName);
            this.lC_Root.Controls.Add(this.txtEdit_Password);
            this.lC_Root.Controls.Add(this.checkEdit_RemindMe);
            this.lC_Root.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lC_Root.Location = new System.Drawing.Point(0, 0);
            this.lC_Root.Name = "lC_Root";
            this.lC_Root.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(444, 7, 650, 400);
            this.lC_Root.Root = this.lCG_Root;
            this.lC_Root.Size = new System.Drawing.Size(258, 195);
            this.lC_Root.TabIndex = 2;
            // 
            // btn_POS
            // 
            this.btn_POS.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btn_POS.Appearance.Options.UseFont = true;
            this.btn_POS.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_POS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_POS.ImageOptions.SvgImage")));
            this.btn_POS.Location = new System.Drawing.Point(12, 84);
            this.btn_POS.Name = "btn_POS";
            this.btn_POS.Size = new System.Drawing.Size(115, 99);
            this.btn_POS.StyleController = this.lC_Root;
            this.btn_POS.TabIndex = 1;
            this.btn_POS.Text = "Satış";
            this.btn_POS.Click += new System.EventHandler(this.btn_POS_Click);
            // 
            // txtEdit_UserName
            // 
            this.txtEdit_UserName.Location = new System.Drawing.Point(59, 12);
            this.txtEdit_UserName.Name = "txtEdit_UserName";
            this.txtEdit_UserName.Size = new System.Drawing.Size(187, 20);
            this.txtEdit_UserName.StyleController = this.lC_Root;
            this.txtEdit_UserName.TabIndex = 4;
            // 
            // txtEdit_Password
            // 
            this.txtEdit_Password.Location = new System.Drawing.Point(59, 36);
            this.txtEdit_Password.Name = "txtEdit_Password";
            this.txtEdit_Password.Size = new System.Drawing.Size(187, 20);
            this.txtEdit_Password.StyleController = this.lC_Root;
            this.txtEdit_Password.TabIndex = 5;
            // 
            // checkEdit_RemindMe
            // 
            this.checkEdit_RemindMe.Location = new System.Drawing.Point(12, 60);
            this.checkEdit_RemindMe.Name = "checkEdit_RemindMe";
            this.checkEdit_RemindMe.Properties.Caption = "meni xatırla";
            this.checkEdit_RemindMe.Size = new System.Drawing.Size(234, 20);
            this.checkEdit_RemindMe.StyleController = this.lC_Root;
            this.checkEdit_RemindMe.TabIndex = 6;
            // 
            // lCG_Root
            // 
            this.lCG_Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lCG_Root.GroupBordersVisible = false;
            this.lCG_Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lCI_ERP,
            this.lCI_POS,
            this.lCI_UserName,
            this.lCI_Password,
            this.lCI_RemindMe});
            this.lCG_Root.Name = "lCG_Root";
            this.lCG_Root.Size = new System.Drawing.Size(258, 195);
            this.lCG_Root.TextVisible = false;
            // 
            // lCI_ERP
            // 
            this.lCI_ERP.Control = this.btn_ERP;
            this.lCI_ERP.Location = new System.Drawing.Point(119, 72);
            this.lCI_ERP.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_ERP.Name = "lCI_ERP";
            this.lCI_ERP.Size = new System.Drawing.Size(119, 103);
            this.lCI_ERP.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_ERP.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_ERP.TextVisible = false;
            // 
            // lCI_POS
            // 
            this.lCI_POS.Control = this.btn_POS;
            this.lCI_POS.Location = new System.Drawing.Point(0, 72);
            this.lCI_POS.MinSize = new System.Drawing.Size(78, 26);
            this.lCI_POS.Name = "lCI_POS";
            this.lCI_POS.Size = new System.Drawing.Size(119, 103);
            this.lCI_POS.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lCI_POS.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_POS.TextVisible = false;
            // 
            // lCI_UserName
            // 
            this.lCI_UserName.Control = this.txtEdit_UserName;
            this.lCI_UserName.Location = new System.Drawing.Point(0, 0);
            this.lCI_UserName.Name = "lCI_UserName";
            this.lCI_UserName.Size = new System.Drawing.Size(238, 24);
            this.lCI_UserName.Text = "İstifadəçi";
            this.lCI_UserName.TextSize = new System.Drawing.Size(44, 13);
            // 
            // lCI_Password
            // 
            this.lCI_Password.Control = this.txtEdit_Password;
            this.lCI_Password.Location = new System.Drawing.Point(0, 24);
            this.lCI_Password.Name = "lCI_Password";
            this.lCI_Password.Size = new System.Drawing.Size(238, 24);
            this.lCI_Password.Text = "Şifrə";
            this.lCI_Password.TextSize = new System.Drawing.Size(44, 13);
            // 
            // lCI_RemindMe
            // 
            this.lCI_RemindMe.Control = this.checkEdit_RemindMe;
            this.lCI_RemindMe.Location = new System.Drawing.Point(0, 48);
            this.lCI_RemindMe.Name = "lCI_RemindMe";
            this.lCI_RemindMe.Size = new System.Drawing.Size(238, 24);
            this.lCI_RemindMe.TextSize = new System.Drawing.Size(0, 0);
            this.lCI_RemindMe.TextVisible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 195);
            this.Controls.Add(this.lC_Root);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.lC_Root)).EndInit();
            this.lC_Root.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_RemindMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCG_Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_ERP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_POS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lCI_RemindMe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_ERP;
        private DevExpress.XtraLayout.LayoutControl lC_Root;
        private DevExpress.XtraEditors.SimpleButton btn_POS;
        private DevExpress.XtraLayout.LayoutControlGroup lCG_Root;
        private DevExpress.XtraLayout.LayoutControlItem lCI_POS;
        private DevExpress.XtraLayout.LayoutControlItem lCI_ERP;
        private DevExpress.XtraEditors.TextEdit txtEdit_UserName;
        private DevExpress.XtraEditors.TextEdit txtEdit_Password;
        private DevExpress.XtraLayout.LayoutControlItem lCI_UserName;
        private DevExpress.XtraLayout.LayoutControlItem lCI_Password;
        private DevExpress.XtraEditors.CheckEdit checkEdit_RemindMe;
        private DevExpress.XtraLayout.LayoutControlItem lCI_RemindMe;
    }
}