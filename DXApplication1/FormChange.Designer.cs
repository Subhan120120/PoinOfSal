
namespace DXApplication1
{
    partial class FormChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChange));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditCash = new DevExpress.XtraEditors.TextEdit();
            this.textEditChange = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemCash = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemChange = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditChange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditCash);
            this.layoutControl1.Controls.Add(this.textEditChange);
            this.layoutControl1.Controls.Add(this.simpleButtonOk);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(288, 214);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEditCash
            // 
            this.textEditCash.Location = new System.Drawing.Point(93, 12);
            this.textEditCash.Name = "textEditCash";
            this.textEditCash.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textEditCash.Properties.Appearance.Options.UseFont = true;
            this.textEditCash.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditCash.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditCash.Size = new System.Drawing.Size(183, 22);
            this.textEditCash.StyleController = this.layoutControl1;
            this.textEditCash.TabIndex = 4;
            // 
            // textEditChange
            // 
            this.textEditChange.Location = new System.Drawing.Point(93, 38);
            this.textEditChange.Name = "textEditChange";
            this.textEditChange.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 40F);
            this.textEditChange.Properties.Appearance.Options.UseFont = true;
            this.textEditChange.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditChange.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditChange.Size = new System.Drawing.Size(183, 70);
            this.textEditChange.StyleController = this.layoutControl1;
            this.textEditChange.TabIndex = 5;
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonOk.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonOk.ImageOptions.SvgImage")));
            this.simpleButtonOk.Location = new System.Drawing.Point(12, 112);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(264, 90);
            this.simpleButtonOk.StyleController = this.layoutControl1;
            this.simpleButtonOk.TabIndex = 6;
            this.simpleButtonOk.Text = "simpleButton1";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemCash,
            this.layoutControlItemChange,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(288, 214);
            this.Root.TextVisible = false;
            // 
            // layoutControlItemCash
            // 
            this.layoutControlItemCash.Control = this.textEditCash;
            this.layoutControlItemCash.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemCash.Name = "layoutControlItemCash";
            this.layoutControlItemCash.Size = new System.Drawing.Size(268, 26);
            this.layoutControlItemCash.Text = "Nağd ödəmə";
            this.layoutControlItemCash.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItemChange
            // 
            this.layoutControlItemChange.Control = this.textEditChange;
            this.layoutControlItemChange.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("layoutControlItemChange.ImageOptions.SvgImage")));
            this.layoutControlItemChange.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemChange.Name = "layoutControlItemChange";
            this.layoutControlItemChange.Size = new System.Drawing.Size(268, 74);
            this.layoutControlItemChange.Text = "Pul qalığı";
            this.layoutControlItemChange.TextSize = new System.Drawing.Size(78, 32);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButtonOk;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(78, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(268, 94);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FormChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 214);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormChange";
            this.Load += new System.EventHandler(this.FormChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditCash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditChange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit textEditCash;
        private DevExpress.XtraEditors.TextEdit textEditChange;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCash;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemChange;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}