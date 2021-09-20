namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trShipmentLine")]
    public partial class trShipmentLine
    {
        [Key]
        public Guid ShipmentLineID { get; set; }

        public Guid ShipmentHeaderID { get; set; }

        public int SortOrder { get; set; }

        public byte ItemTypeCode { get; set; }

        [Required]
        [StringLength(30)]
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
        [StringLength(30)]
        public string UsedBarcode { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual trShipmentHeader trShipmentHeader { get; set; }
    }
}
