namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trPaymentHeader")]
    public partial class trPaymentHeader
    {
        [Key]
        public Guid PaymentHeaderID { get; set; }

        public Guid? InvoiceHeaderID { get; set; }

        [Required]
        [StringLength(30)]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocumentDate { get; set; }

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

        [Column(TypeName = "numeric")]
        public decimal CompanyCode { get; set; }

        [Required]
        [StringLength(5)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StoreCode { get; set; }

        public short POSTerminalID { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        public double ExchangeRate { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsLocked { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
