using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrShipmentLine
    {
        [Key]
        public Guid ShipmentLineId { get; set; }

        [ForeignKey("TrShipmentHeader")]
        public Guid ShipmentHeaderId { get; set; }
        public int SortOrder { get; set; }
        public byte ItemTypeCode { get; set; }
        public string ProductCode { get; set; }

        [Required]
        [StringLength(10)]
        public string ColorCode { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductDimensionCode { get; set; }
        public double Qty { get; set; }

        [Required]
        [StringLength(10)]
        public string SalespersonCode { get; set; }

        [Required]
        [StringLength(200)]
        public string LineDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string UsedBarcode { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

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


        public virtual TrShipmentHeader TrShipmentHeader { get; set; }
    }
}
