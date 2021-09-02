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
    public partial class UcReturn : XtraUserControl
    {
        SqlMethods SqlMethods = new SqlMethods();
        public UcReturn()
        {
            InitializeComponent();
        }

        private void UcReturn_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = SqlMethods.SelectInvoiceHeader();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object invoiceHeaderID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InvoiceHeaderID");
            gridControl2.DataSource = SqlMethods.SelectInvoiceLine(invoiceHeaderID.ToString());
            gridControl3.DataSource = SqlMethods.SelectPaymentLine(invoiceHeaderID.ToString());
        }
    }
}
