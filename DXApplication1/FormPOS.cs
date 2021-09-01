using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPOS : ToolbarForm
    {
        public FormPOS()
        {
            InitializeComponent();

            foreach (NavigationPageBase page in navigationFrame1.Pages) //create formToolbarItem for NavigationFrame Pages
            {
                BarCheckItem newBarItem = new BarCheckItem(toolbarFormManager1, false);

                newBarItem.ItemClick += (s, e) =>
                {
                    navigationFrame1.SelectedPage = (NavigationPage)page;

                    BarCheckItem clickedBarItem = e.Item as BarCheckItem;
                    foreach (BarItem control in toolbarFormManager1.Items)
                    {
                        BarCheckItem ctrl = control as BarCheckItem;
                        if (ctrl == clickedBarItem)
                            clickedBarItem.Checked = true;
                        else
                            ctrl.Checked = false;
                    }
                };

                newBarItem.CheckedChanged += (s, e) =>
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

                };

                bool IsActiv = false;
                if (navigationFrame1.SelectedPage == (NavigationPage)page)
                    IsActiv = true;
                newBarItem.Checked = IsActiv;

                newBarItem.Hint = page.ControlName;
                newBarItem.Caption = page.ControlName;

                toolbarFormControl1.TitleItemLinks.Add(newBarItem);
                toolbarFormManager1.Items.Add(newBarItem);
            }
        }

        private void FormPOS_Load(object sender, EventArgs e)
        {
            UcSale ucSale = new UcSale();
            ucSale.Dock = DockStyle.Fill;
            AcceptButton = ucSale.simpleButtonEnter;
            navigationPageSale.Controls.Add(ucSale);
        }

        private void officeNavigationBar1_ItemClick(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (e.Item.Name == "navigationBarItemExit")
                this.Close();
        }
    }
}