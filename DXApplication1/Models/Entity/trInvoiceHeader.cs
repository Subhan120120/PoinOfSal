namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trInvoiceHeader")]
    public partial class trInvoiceHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trInvoiceHeader()
        {
            trInvoiceLines = new HashSet<trInvoiceLine>();
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
        public DateTime? DocumentDate { get; set; }

        public TimeSpan DocumentTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        public TimeSpan OperationTime { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [StringLength(30)]
        public string CurrAccCode { get; set; }

        [StringLength(10)]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(10)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(10)]
        public string WarehouseCode { get; set; }

        [StringLength(30)]
        public string CustomsDocumentNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string POSTerminalId { get; set; }

        public bool IsSuspended { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPrinted { get; set; }

        public bool IsLocked { get; set; }

        public byte FiscalPrintedState { get; set; }

        public bool IsSalesViaInternet { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual dcCurrAcc dcCurrAcc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trInvoiceLine> trInvoiceLines { get; set; }
    }
}
