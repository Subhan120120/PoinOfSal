﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models
{
    public partial class TrPrice : BaseEntity
    {
        [Key]
        public int PriceCode { get; set; }

        [Required]
        [ForeignKey("DcProduct")]
        public string ProductCode { get; set; }

        [DisplayName("Qiymət")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        public double Price { get; set; }

        public virtual DcProduct DcProduct { get; set; }
    }
}
