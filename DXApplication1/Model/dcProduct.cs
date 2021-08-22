using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Model
{
    public class dcProduct
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string Barcode { get; set; }
        public decimal PosDiscount { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
