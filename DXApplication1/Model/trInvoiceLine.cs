﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Model
{
    public class trInvoiceLine
    {
        public string InvoiceLineId { get; set; }
        public string InvoiceHeaderId { get; set; }
        public string RelatedLineId { get; set; }
        public string ProductCode { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal PosDiscount { get; set; }
        public decimal NetAmount { get; set; }
    }
}
