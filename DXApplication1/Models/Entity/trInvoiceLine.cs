using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrInvoiceLine : BaseEntity
    {
        [Key]
        public Guid InvoiceLineId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        public Guid InvoiceHeaderId { get; set; }

        public Guid? RelatedLineId { get; set; }

        [StringLength(30)]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public double Price { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal PosDiscount { get; set; }

        [Column(TypeName = "money")]
        public decimal DiscountCampaign { get; set; }

        [Column(TypeName = "money")]
        public decimal NetAmount { get; set; }

        public float VatRate { get; set; }

        public string LineDescription { get; set; }

        [StringLength(50)]
        public string SalesPersonCode { get; set; }

        [StringLength(10)]
        public string CurrencyCode { get; set; }

        public double ExchangeRate { get; set; }


        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
        public virtual DcProduct DcProduct { get; set; }
    }
}
