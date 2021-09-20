namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcPaymentType")]
    public partial class dcPaymentType
    {
        [Key]
        public byte PaymentTypeCode { get; set; }

        [StringLength(100)]
        public string PaymentTypeDescription { get; set; }
    }
}
