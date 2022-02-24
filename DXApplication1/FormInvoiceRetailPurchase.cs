using DevExpress.Utils.VisualEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormInvoiceRetailPurchase : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public FormInvoiceRetailPurchase()
        {
            InitializeComponent();

            //UcInvoice ucInvoice = new UcInvoice();
            //ucInvoice.Dock = DockStyle.Fill;
            //this.Controls.Add(ucInvoice);

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            //badge1.TargetElement = bBI_Save;
            //badge2.TargetElement = RibbonPage_Invoice;
        }

        public AdornerElement[] Badges { get { return new AdornerElement[] { badge1, badge2 }; } }
    }
}
