using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars;
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
    public partial class FormTransfer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;

        public FormTransfer()
        {
            InitializeComponent();

            adornerUIManager1 = new AdornerUIManager(components);
            badge1 = new Badge();
            badge2 = new Badge();
            adornerUIManager1.Elements.Add(badge1);
            adornerUIManager1.Elements.Add(badge2);
            badge1.TargetElement = barButtonItem1;
            badge2.TargetElement = ribbonPage1;
        }

        public AdornerElement[] Badges
        {
            get
            {
                return new AdornerElement[] { badge1, badge2 };
            }
        }
    }
}