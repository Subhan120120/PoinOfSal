using DevExpress.Utils.VisualEffects;
using DevExpress.XtraBars.Ribbon;
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

namespace PointOfSale
{
    public partial class FormReport : RibbonForm
    {
        Badge badge1;
        Badge badge2;
        AdornerUIManager adornerUIManager1;
        EfMethods efMethods = new EfMethods();
        public FormReport()
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

        private void FormReport_Load(object sender, EventArgs e)
        {
            WindowsFormsSettings.FilterCriteriaDisplayStyle = FilterCriteriaDisplayStyle.Text;
            filterControl1.SourceControl = efMethods.SelectStores();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void filterControl1_Click(object sender, EventArgs e)
        {
            string filterString = DevExpress.Data.Filtering.CriteriaToWhereClauseHelper.GetMsSqlWhere(filterControl1.FilterCriteria);
            label1.Text = filterString;
        }
    }
}
