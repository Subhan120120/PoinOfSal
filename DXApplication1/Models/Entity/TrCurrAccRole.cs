using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public partial class TrCurrAccRole : BaseEntity
    {
        [Key]
        public int CurrAccRoleId { get; set; }

        [ForeignKey("DcCurrAcc")]
        public string CurrAccCode { get; set; }

        [ForeignKey("DcRole")]
        public string RoleCode { get; set; }


        public virtual DcCurrAcc DcCurrAcc { get; set; }

        public virtual DcRole DcRole { get; set; }
    }
}
