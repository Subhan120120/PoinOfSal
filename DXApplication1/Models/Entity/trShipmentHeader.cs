using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrShipmentHeader
    {
        public TrShipmentHeader()
        {
            TrShipmentLine = new HashSet<TrShipmentLine>();
        }

        [Key]
        public Guid ShipmentHeaderId { get; set; }
        public byte ShipTypeCode { get; set; }

        [Required]
        [StringLength(5)]
        public string ProcessCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ShippingNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShippingDate { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan ShippingTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan OperationTime { get; set; }

        [StringLength(30)]
        public string CustomsDocumentNumber { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(30)]
        public string CurrAccCode { get; set; }
        public Guid? ShippingPostalAddressId { get; set; }

        [StringLength(10)]
        public decimal CompanyCode { get; set; }

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
        public string ToWarehouseCode { get; set; }
        public bool IsOrderBase { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPrinted { get; set; }
        public bool IsLocked { get; set; }
        public bool IsTransferApproved { get; set; }
        public DateTime TransferApprovedDate { get; set; }

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


        public virtual ICollection<TrShipmentLine> TrShipmentLine { get; set; }
    }
}
