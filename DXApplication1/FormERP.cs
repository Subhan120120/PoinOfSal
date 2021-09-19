using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
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
    public partial class FormERP : RibbonForm
    {
        FormInvoice formInvoice;
        FormTransfer formTransfer;
        AdornerUIManager adornerUIManager1;
        IList<AdornerElement> adorners1;

        public FormERP()
        {
            InitializeComponent();
            adorners1 = new List<AdornerElement>();
            formInvoice = new FormInvoice();
            formInvoice.MdiParent = this;
            adornerUIManager1 = new AdornerUIManager(this.components);

            adorners1 = new List<AdornerElement>();
            formTransfer = new FormTransfer();
            formTransfer.MdiParent = this;
            adornerUIManager1 = new AdornerUIManager(this.components);
        }

        private void RibbonControl1_Merge(object sender, RibbonMergeEventArgs e)
        {
            AdornerElement[] badges = ((FormInvoice)e.MergedChild.Parent).Badges;
            adornerUIManager1.BeginUpdate();
            foreach (AdornerElement badge in badges)
            {
                AdornerElement clone = badge.Clone() as AdornerElement;
                if (badge.TargetElement is BarItem)
                    clone.TargetElement = badge.TargetElement;
                if (badge.TargetElement is RibbonPage)
                    clone.TargetElement = ribbon.MergedPages.GetPageByName((badge.TargetElement as RibbonPage).Name);
                adornerUIManager1.Elements.Add(clone);
                adorners1.Add(clone);
            }
            adornerUIManager1.EndUpdate();
        }

        private void RibbonControl1_UnMerge(object sender, RibbonMergeEventArgs e)
        {
            adornerUIManager1.BeginUpdate();
            foreach (AdornerElement badge in adorners1)
            {
                adornerUIManager1.Elements.Remove(badge);
                badge.Dispose();
            }
            adorners1.Clear();
            adornerUIManager1.EndUpdate();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            FormInvoice formInvoice = Application.OpenForms["FormInvoice"] as FormInvoice;
            if (formInvoice != null)
            {
                formInvoice.BringToFront();
                formInvoice.Activate();
            }
            else
            {
                formInvoice = new FormInvoice();
                formInvoice.MdiParent = this;
                formInvoice.Show();
                ribbon.SelectedPage = ribbon.MergedPages[0];
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseOpenChildForms();
        }

        private void CloseOpenChildForms()
        {
            foreach (var child in this.MdiChildren)
            {
                var myCustomChild = child as RibbonForm;
                if (myCustomChild == null) continue; //if there are any casting problems

                myCustomChild.Close();
            }
        }

        private void aCEshipment_Click(object sender, EventArgs e)
        {
            FormTransfer formTransfer = Application.OpenForms["FormTransfer"] as FormTransfer;
            if (formTransfer != null)
            {
                formTransfer.BringToFront();
                formTransfer.Activate();
            }
            else
            {
                formTransfer = new FormTransfer();
                formTransfer.MdiParent = this;
                formTransfer.Show();
                ribbon.SelectedPage = ribbon.MergedPages[0];
            }
        }

        private void FormERP_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                ribbon.SelectedPage = ribbon.MergedPages[0];
            }
            catch (Exception) { }

        }
    }
}