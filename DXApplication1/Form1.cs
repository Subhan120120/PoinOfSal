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
    public partial class Form1 : Form
    {
        PointOfSale.Models.subContext dbContext = new PointOfSale.Models.subContext();
        public Form1()
        {
            InitializeComponent();

            PointOfSale.Models.subContext dbContext = new PointOfSale.Models.subContext();

            dbContext.TrInvoiceLines.LoadAsync().ContinueWith(loadTask =>
            {
                trInvoiceLinesBindingSource.DataSource = dbContext.TrInvoiceLines.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }
    }
}
