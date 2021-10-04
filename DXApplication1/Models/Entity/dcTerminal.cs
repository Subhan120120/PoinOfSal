using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class DcTerminal : BaseEntity
    {
        [Key]
        [StringLength(50)]
        public string TerminalCode { get; set; }

        [Required]
        [StringLength(150)]
        public string TerminalDesc { get; set; }
        public bool IsDisabled { get; set; }
        public Guid RowGuid { get; set; }
    }
}
