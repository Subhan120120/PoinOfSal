
namespace DXApplication1
{
    partial class FormPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPOS));
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageSale = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.officeNavigationBar1 = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.navigationBarItem1 = new DevExpress.XtraBars.Navigation.NavigationBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPageSale);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageSale});
            this.navigationFrame1.SelectedPage = this.navigationPageSale;
            this.navigationFrame1.Size = new System.Drawing.Size(1159, 649);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPageSale
            // 
            this.navigationPageSale.AccessibleDescription = "";
            this.navigationPageSale.AccessibleName = "";
            this.navigationPageSale.ControlName = "";
            this.navigationPageSale.Name = "navigationPageSale";
            this.navigationPageSale.Size = new System.Drawing.Size(1159, 649);
            // 
            // officeNavigationBar1
            // 
            this.officeNavigationBar1.AutoSize = false;
            this.officeNavigationBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.officeNavigationBar1.Items.AddRange(new DevExpress.XtraBars.Navigation.NavigationBarItem[] {
            this.navigationBarItem1});
            this.officeNavigationBar1.Location = new System.Drawing.Point(0, 0);
            this.officeNavigationBar1.Name = "officeNavigationBar1";
            this.officeNavigationBar1.NavigationClient = this.navigationFrame1;
            this.officeNavigationBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.officeNavigationBar1.Size = new System.Drawing.Size(1159, 46);
            this.officeNavigationBar1.TabIndex = 1;
            this.officeNavigationBar1.Text = "officeNavigationBar1";
            this.officeNavigationBar1.ViewMode = DevExpress.XtraBars.Navigation.OfficeNavigationBarViewMode.Tab;
            this.officeNavigationBar1.ItemClick += new DevExpress.XtraBars.Navigation.NavigationBarItemClickEventHandler(this.officeNavigationBar1_ItemClick);
            // 
            // navigationBarItem1
            // 
            this.navigationBarItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("navigationBarItem1.ImageOptions.SvgImage")));
            this.navigationBarItem1.Name = "navigationBarItem1";
            this.navigationBarItem1.Text = "Exit";
            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 649);
            this.Controls.Add(this.officeNavigationBar1);
            this.Controls.Add(this.navigationFrame1);
            this.Name = "FormPOS";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.FormPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageSale;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar1;
        private DevExpress.XtraBars.Navigation.NavigationBarItem navigationBarItem1;
    }
}