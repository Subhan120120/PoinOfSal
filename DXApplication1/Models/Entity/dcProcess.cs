using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class DcProcess
    {
        [Key]
        [StringLength(5)]
        public string ProcessCode { get; set; }

        [StringLength(200)]
        public string ProcessDescription { get; set; }
        public int? LastNumber { get; set; }
    }
}
