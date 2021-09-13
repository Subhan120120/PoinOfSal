
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;

namespace DXApplication1
{
    partial class FormPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.navigationPageReturn = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.ucReturn = new DXApplication1.UcReturn();
            this.navigationPageSale = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.ucSale = new DXApplication1.UcSale();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            this.navigationPageReturn.SuspendLayout();
            this.navigationPageSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarFormControl1
            // 
            this.toolbarFormControl1.Location = new System.Drawing.Point(0, 0);
            this.toolbarFormControl1.Manager = this.toolbarFormManager1;
            this.toolbarFormControl1.Name = "toolbarFormControl1";
            this.toolbarFormControl1.Size = new System.Drawing.Size(1242, 31);
            this.toolbarFormControl1.TabIndex = 1;
            this.toolbarFormControl1.TabStop = false;
            this.toolbarFormControl1.TitleItemLinks.Add(this.barCheckItem1);
            this.toolbarFormControl1.TitleItemLinks.Add(this.barCheckItem2);
            this.toolbarFormControl1.ToolbarForm = this;
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            this.toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCheckItem1,
            this.barCheckItem2});
            this.toolbarFormManager1.MaxItemId = 24;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 31);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1242, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 649);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1242, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 618);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1242, 31);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 618);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.BindableChecked = true;
            this.barCheckItem1.Caption = "Satış";
            this.barCheckItem1.Checked = true;
            this.barCheckItem1.Id = 20;
            this.barCheckItem1.Name = "barCheckItem1";
            this.barCheckItem1.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_CheckedChanged);
            this.barCheckItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem1_ItemClick);
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "Geri Qaytarma";
            this.barCheckItem2.Id = 22;
            this.barCheckItem2.Name = "barCheckItem2";
            this.barCheckItem2.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem2_CheckedChanged);
            this.barCheckItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCheckItem2_ItemClick);
            // 
            // navigationPageReturn
            // 
            this.navigationPageReturn.ControlName = "GeriQaytarma";
            this.navigationPageReturn.Controls.Add(this.ucReturn);
            this.navigationPageReturn.Name = "navigationPageReturn";
            this.navigationPageReturn.Size = new System.Drawing.Size(1242, 618);
            // 
            // ucReturn
            // 
            this.ucReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReturn.Location = new System.Drawing.Point(0, 0);
            this.ucReturn.Name = "ucReturn";
            this.ucReturn.Size = new System.Drawing.Size(1242, 618);
            this.ucReturn.TabIndex = 0;
            // 
            // navigationPageSale
            // 
            this.navigationPageSale.ControlName = "Satış";
            this.navigationPageSale.Controls.Add(this.ucSale);
            this.navigationPageSale.Name = "navigationPageSale";
            this.navigationPageSale.Size = new System.Drawing.Size(1242, 618);
            // 
            // ucSale
            // 
            this.ucSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSale.Location = new System.Drawing.Point(0, 0);
            this.ucSale.Name = "ucSale";
            this.ucSale.Size = new System.Drawing.Size(1242, 618);
            this.ucSale.TabIndex = 0;
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPageSale);
            this.navigationFrame1.Controls.Add(this.navigationPageReturn);
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 31);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageSale,
            this.navigationPageReturn,
            this.navigationPage1});
            this.navigationFrame1.SelectedPage = this.navigationPageSale;
            this.navigationFrame1.Size = new System.Drawing.Size(1242, 618);
            this.navigationFrame1.TabIndex = 0;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.ControlName = "3cu page";
            this.navigationPage1.ControlTypeName = "";
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(1242, 618);
            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 649);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.toolbarFormControl1);
            this.Name = "FormPOS";
            this.ToolbarFormControl = this.toolbarFormControl1;
            this.Load += new System.EventHandler(this.FormPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            this.navigationPageReturn.ResumeLayout(false);
            this.navigationPageSale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolbarFormControl toolbarFormControl1;
        private ToolbarFormManager toolbarFormManager1;
        private NavigationFrame navigationFrame1;
        private NavigationPage navigationPageSale;
        private NavigationPage navigationPageReturn;
        private NavigationPage navigationPage1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private UcSale ucSale;
        private UcReturn ucReturn;
        private BarCheckItem barCheckItem1;
        private BarCheckItem barCheckItem2;
    }
}