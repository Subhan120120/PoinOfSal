﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public partial class AppSetting
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Cədvəl Dizaynı")]
        public string GridViewLayout { get; set; }

        [DisplayName("Print Edilsin")]
        public bool GetPrint { get; set; }

        [DisplayName("Printer Adı")]
        public string PrinterName { get; set; }

        [DisplayName("Çap sayı")]
        public int PrinterCopyNum { get; set; }


        [DisplayName("Print Dizayn Yolu")]
        public string PrintDesignPath { get; set; }

    }
}
