using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    [Table("DcProductType")]
    public partial class DcProductType
    {
        public DcProductType()
        {
            DcProduct = new HashSet<DcProduct>();
        }

        [Key]
        public byte ProductTypeCode { get; set; }

        [StringLength(50)]
        public string ProductTypeDesc { get; set; }

        public virtual ICollection<DcProduct> DcProduct { get; set; }
    }
}
