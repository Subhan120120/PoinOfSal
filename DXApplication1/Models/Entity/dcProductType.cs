namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcProductType")]
    public partial class dcProductType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dcProductType()
        {
            dcProducts = new HashSet<dcProduct>();
        }

        [Key]
        public byte ProductTypeCode { get; set; }

        [StringLength(50)]
        public string ProductTypeDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dcProduct> dcProducts { get; set; }
    }
}
