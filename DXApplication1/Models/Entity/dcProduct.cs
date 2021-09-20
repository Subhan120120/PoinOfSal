namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcProduct")]
    public partial class dcProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dcProduct()
        {
            trInvoiceLines = new HashSet<trInvoiceLine>();
        }

        [Key]
        [StringLength(150)]
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

        public virtual dcProductType dcProductType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trInvoiceLine> trInvoiceLines { get; set; }
    }
}
