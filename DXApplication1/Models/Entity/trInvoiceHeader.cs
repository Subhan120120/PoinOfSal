using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
//#nullable disable

namespace PointOfSale.Models
{
    public partial class TrInvoiceHeader : BaseEntity
    {
        public TrInvoiceHeader()
        {
            TrInvoiceLines = new HashSet<TrInvoiceLine>();
        }

        [Key]
        public Guid InvoiceHeaderId { get; set; }
        public Guid? RelatedInvoiceId { get; set; }

        [Required]
        [StringLength(5)]
        public string ProcessCode { get; set; }

        [Required]
        [StringLength(30)]
        public string DocumentNumber { get; set; }
        public bool IsReturn { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan OperationTime { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

#nullable enable
        [StringLength(30)]
        [ForeignKey("DcCurrAcc")]
        public string? CurrAccCode { get; set; }
#nullable disable
        [Required]
        [StringLength(10)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(30)]
        public string WarehouseCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomsDocumentNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string PosTerminalId { get; set; }

        public bool IsSuspended { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPrinted { get; set; }

        public bool IsLocked { get; set; }

        public byte FiscalPrintedState { get; set; }

        public bool IsSalesViaInternet { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }
        public virtual ICollection<TrInvoiceLine> TrInvoiceLines { get; set; }
        public virtual ICollection<TrPaymentHeader> TrPaymentHeaders { get; set; }
    }
}
