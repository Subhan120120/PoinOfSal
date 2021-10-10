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
using Microsoft.EntityFrameworkCore;

namespace PointOfSale
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        PointOfSale.Models.subContext dbContext = new PointOfSale.Models.subContext();            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
        public XtraForm1()
        {
            InitializeComponent();
            dbContext.TrPaymentLines.LoadAsync().ContinueWith(loadTask =>
            {
                trPaymentLinesBindingSource.DataSource = dbContext.TrPaymentLines.Local.ToBindingList();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            dbContext.SaveChanges();
        }
    }
}