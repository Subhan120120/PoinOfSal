using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Model
{
    public class trPaymentLine
    {
        public string PaymentLineID { get; set; }
        public string PaymentHeaderID { get; set; }
        public int PaymentTypeCode { get; set; }
        public decimal Payment { get; set; }
    }
}
