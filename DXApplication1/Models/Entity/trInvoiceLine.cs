namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trInvoiceLine")]
    public partial class trInvoiceLine
    {
        [Key]
        public Guid InvoiceLineId { get; set; }

        public Guid InvoiceHeaderId { get; set; }

        public Guid? RelatedLineId { get; set; }

        [StringLength(150)]
        public string ProductCode { get; set; }

        public int? Qty { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "money")]
        public decimal? PosDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountCampaign { get; set; }

        [Column(TypeName = "money")]
        public decimal? NetAmount { get; set; }

        public float? VatRate { get; set; }

        public string LineDescription { get; set; }

        [StringLength(50)]
        public string SalespersonCode { get; set; }

        [StringLength(10)]
        public string CurrencyCode { get; set; }

        public double? ExchangeRate { get; set; }

        [StringLength(50)]
        public string CreatedUserName { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string LastUpdatedUserName { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public virtual dcProduct dcProduct { get; set; }

        public virtual trInvoiceHeader trInvoiceHeader { get; set; }
    }
}
