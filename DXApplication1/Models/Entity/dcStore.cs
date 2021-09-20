namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcStore")]
    public partial class dcStore
    {
        [Key]
        [StringLength(50)]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(150)]
        public string StoreDesc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CompanyCode { get; set; }

        public bool IsDisabled { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public Guid RowGuid { get; set; }
    }
}
