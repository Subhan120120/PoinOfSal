using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public partial class DcFeature
    {
        public DcFeature()
        {
            TrFeatures = new HashSet<TrFeature>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FeatureName { get; set; }

        public virtual ICollection<TrFeature> TrFeatures { get; set; }
    }
}
