using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.ToolbarForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class FormPOS : ToolbarForm
    {

        public FormPOS()
        {
            InitializeComponent();

            foreach (NavigationPage page in navigationFrame1.Pages) //create formToolbarItem for NavigationFrame Pages
            {
                BarCheckItem newBarItem = new BarCheckItem(toolbarFormManager1, false);

                newBarItem.ItemClick += (s, e) =>
                {
                    navigationFrame1.SelectedPage = page;

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
                if (navigationFrame1.SelectedPage == page)
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
            navigationPageSale.Controls.Add(ucSale);
            AcceptButton = ucSale.simpleButtonEnter;

            UcReturn ucReturn = new UcReturn();
            ucReturn.Dock = DockStyle.Fill;
            navigationPageReturn.Controls.Add(ucReturn);
        }
    }
}