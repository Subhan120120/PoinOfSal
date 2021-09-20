namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcProcess")]
    public partial class dcProcess
    {
        [Key]
        [StringLength(5)]
        public string ProcessCode { get; set; }

        [StringLength(200)]
        public string ProcessDescription { get; set; }

        public int? LastNumber { get; set; }
    }
}
