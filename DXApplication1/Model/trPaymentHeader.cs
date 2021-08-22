using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Model
{
    public class trPaymentHeader
    {
        public string PaymentHeaderID { get; set; }
        public string InvoiceHeaderID { get; set; }
        public string DocumentNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string CurrAccCode { get; set; }        
    }
}
