using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    [Table("DcProduct")]
    public partial class DcProduct
    {
        public DcProduct()
        {
            TrInvoiceLine = new HashSet<TrInvoiceLine>();
        }

        [Key]
        [StringLength(30)]
        public string ProductCode { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        public byte? ProductTypeCode { get; set; }
        public bool? UsePos { get; set; }

        [StringLength(50)]
        public string PromotionCode { get; set; }

        [StringLength(50)]
        public string PromotionCode2 { get; set; }
        public double? TaxRate { get; set; }
        public double? PosDiscount { get; set; }
        public bool? IsDisabled { get; set; }
        public double? RetailPrice { get; set; }
        public double? PurchasePrice { get; set; }
        public double? WholesalePrice { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? UseInternet { get; set; }

        [StringLength(150)]
        public string ProductDescription { get; set; }

        public virtual DcProductType ProductTypeCodeNavigation { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLine { get; set; }
    }
}
