using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormProduct : XtraForm
    {
        subContext dbContext = new subContext();
        string productCode { get; set; }

        public FormProduct()
        {
            InitializeComponent();
            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormProduct(string productCode)
            : this()
        {
            this.productCode = productCode;
        }

        private void FormProduct_Load(object sender, System.EventArgs e)
        {
            DcProduct dcProduct;

            if (string.IsNullOrEmpty(productCode))
            {
                dcProduct = dcProductsBindingSource.AddNew() as DcProduct;
                dcProduct.ProductCode = "";
            }

            dbContext.DcProducts.Where(x => x.ProductCode == productCode).LoadAsync().ContinueWith(loadTask => dcProductsBindingSource.DataSource = dbContext.DcProducts.Local.ToBindingList(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btn_Ok_Click(object sender, System.EventArgs e)
        {
            dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}