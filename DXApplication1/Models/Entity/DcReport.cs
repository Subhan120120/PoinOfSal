using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public partial class DcReport : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string ReportName { get; set; }

        public string ReportQuery { get; set; }
    }
}
