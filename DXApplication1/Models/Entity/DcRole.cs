using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public partial class DcRole : BaseEntity
    {
        public DcRole()
        {
            TrRoleClaims = new HashSet<TrRoleClaim>();
            TrCurrAccRoles = new HashSet<TrCurrAccRole>();
        }

        [Key]
        public string RoleCode { get; set; }

        [Required]
        public string RoleDesc { get; set; }


        public virtual ICollection<TrRoleClaim> TrRoleClaims { get; set; }
        public virtual ICollection<TrCurrAccRole> TrCurrAccRoles { get; set; }

    }
}
