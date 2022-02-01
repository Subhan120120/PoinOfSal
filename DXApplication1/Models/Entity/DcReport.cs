using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public partial class DcReport : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string ReportName { get; set; }

        public string ReportQuery { get; set; }

        public string ReportLayout { get; set; }
        public string ReportFilter { get; set; }

    }
}
