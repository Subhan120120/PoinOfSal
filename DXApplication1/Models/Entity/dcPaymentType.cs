using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class DcPaymentType
    {
        [Key]
        public byte PaymentTypeCode { get; set; }

        [StringLength(100)]
        public string PaymentTypeDesc { get; set; }

        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
    }
}
