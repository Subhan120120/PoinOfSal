using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrPaymentHeader
    {
        [Key]
        public Guid PaymentHeaderId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        public Guid? InvoiceHeaderId { get; set; }
        public string DocumentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan DocumentTime { get; set; }

        [Required]
        [StringLength(30)]
        public string InvoiceNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string CurrAccCode { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public decimal CompanyCode { get; set; }

        [Required]
        [StringLength(5)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StoreCode { get; set; }
        public short PosterminalId { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }
        public double ExchangeRate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsLocked { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }


        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
    }
}
