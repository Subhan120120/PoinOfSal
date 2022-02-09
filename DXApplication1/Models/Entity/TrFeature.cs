using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models
{
    public partial class TrFeature
    {
        public TrFeature()
        {
            //TrRoleClaims = new HashSet<TrRoleClaim>();
        }

        [Key]
        public int Id { get; set; }


        [ForeignKey("DcFeature")]
        public int FeatureId { get; set; }


        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }


        public virtual DcFeature DcFeature { get; set; }

        public virtual DcProduct DcProduct { get; set; }
    }
}
