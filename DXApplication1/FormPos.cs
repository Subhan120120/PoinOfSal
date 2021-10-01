using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormPOS : ToolbarForm
    {
        public FormPOS()
        {
            InitializeComponent();
            UcSale ucSale = new UcSale();
            ucSale.Dock = DockStyle.Fill;
            this.navigationPageSale.Controls.Add(ucSale);

            UcReturn ucReturn = new UcReturn();
            ucReturn.Dock = DockStyle.Fill;
            this.navigationPageReturn.Controls.Add(ucReturn);
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            //AcceptButton = ucSale.simpleButtonEnter;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem clickedBarItem = e.Item as BarCheckItem;
            if (clickedBarItem.Checked)
            {
                clickedBarItem.ItemAppearance.Normal.Font = new Font("Tahoma", 10F, FontStyle.Regular);
                clickedBarItem.ItemAppearance.Normal.ForeColor = Color.FromArgb(0, 0, 192);
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = true;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = true;
            }
            else
            {
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = false;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = false;
            }
        }

        private void barCheckItem2_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            BarCheckItem clickedBarItem = e.Item as BarCheckItem;
            if (clickedBarItem.Checked)
            {
                clickedBarItem.ItemAppearance.Normal.Font = new Font("Tahoma", 10F, FontStyle.Regular);
                clickedBarItem.ItemAppearance.Normal.ForeColor = Color.FromArgb(0, 0, 192);
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = true;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = true;
            }
            else
            {
                clickedBarItem.ItemAppearance.Normal.Options.UseFont = false;
                clickedBarItem.ItemAppearance.Normal.Options.UseForeColor = false;
            }
        }

        private void barCheckItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageReturn;
            BarCheckItem clickedBarItem = e.Item as BarCheckItem;
            foreach (BarItem control in toolbarFormManager1.Items)
            {
                BarCheckItem ctrl = control as BarCheckItem;
                if (ctrl == clickedBarItem)
                    clickedBarItem.Checked = true;
                else
                    ctrl.Checked = false;
            }
        }

        private void barCheckItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPageSale;
            BarCheckItem clickedBarItem = e.Item as BarCheckItem;
            foreach (BarItem control in toolbarFormManager1.Items)
            {
                BarCheckItem ctrl = control as BarCheckItem;
                if (ctrl == clickedBarItem)
                    clickedBarItem.Checked = true;
                else
                    ctrl.Checked = false;
            }
        }
    }
}