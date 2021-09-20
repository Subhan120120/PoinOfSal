namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcTerminal")]
    public partial class dcTerminal
    {
        [Key]
        [StringLength(50)]
        public string TerminalCode { get; set; }

        [Required]
        [StringLength(150)]
        public string TerminalDesc { get; set; }

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
