using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class trPaymentHeader
    {
        public string PaymentHeaderID { get; set; }
        public string InvoiceHeaderId { get; set; }
        public string DocumentNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string CurrAccCode { get; set; }        
    }
}
