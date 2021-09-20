namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trShipmentHeader")]
    public partial class trShipmentHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trShipmentHeader()
        {
            trShipmentLines = new HashSet<trShipmentLine>();
        }

        [Key]
        public Guid ShipmentHeaderID { get; set; }

        public byte ShipTypeCode { get; set; }

        [Required]
        [StringLength(5)]
        public string ProcessCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ShippingNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShippingDate { get; set; }

        public TimeSpan ShippingTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        public TimeSpan OperationTime { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomsDocumentNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(30)]
        public string CurrAccCode { get; set; }

        public Guid? ShippingPostalAddressID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CompanyCode { get; set; }

        [Required]
        [StringLength(5)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(30)]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(10)]
        public string WarehouseCode { get; set; }

        [Required]
        [StringLength(10)]
        public string ToWarehouseCode { get; set; }

        public bool IsOrderBase { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsPrinted { get; set; }

        public bool IsLocked { get; set; }

        public bool IsTransferApproved { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransferApprovedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trShipmentLine> trShipmentLines { get; set; }
    }
}
