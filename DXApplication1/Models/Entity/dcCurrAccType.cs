namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcCurrAccType")]
    public partial class dcCurrAccType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dcCurrAccType()
        {
            dcCurrAccs = new HashSet<dcCurrAcc>();
        }

        [Key]
        public byte CurrAccTypeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string CurrAccTypeDescription { get; set; }

        public bool IsDisabled { get; set; }

        public Guid RowGuid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dcCurrAcc> dcCurrAccs { get; set; }
    }
}
