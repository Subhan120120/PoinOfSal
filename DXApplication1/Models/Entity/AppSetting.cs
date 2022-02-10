using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public partial class AppSetting
    {

        [Key]
        public int Id { get; set; }

        public string GridViewLayout { get; set; }
        public bool GetPrint { get; set; }
        public string PrinterName { get; set; }
        public int PrinterCopyNum { get; set; }
        public string PrintDesignPath { get; set; }

    }
}
