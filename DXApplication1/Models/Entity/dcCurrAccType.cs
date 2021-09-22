using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    [Table("DcCurrAccType")]
    public partial class DcCurrAccType
    {
        public DcCurrAccType()
        {
            DcCurrAcc = new HashSet<DcCurrAcc>();
        }

        [Key]
        public byte CurrAccTypeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string CurrAccTypeDescription { get; set; }
        public bool IsDisabled { get; set; }
        public Guid RowGuid { get; set; }

        public virtual ICollection<DcCurrAcc> DcCurrAcc { get; set; }
    }
}
