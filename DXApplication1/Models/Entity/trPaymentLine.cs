using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrPaymentLine
    {
        [Key]
        public Guid PaymentLineId { get; set; }

        [ForeignKey("TrPaymentHeader")]
        public Guid PaymentHeaderId { get; set; }

        [ForeignKey("DcPaymentType")]
        public byte PaymentTypeCode { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Payment { get; set; }

        [Required]
        [StringLength(200)]
        public string LineDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        [Required]
        public double ExchangeRate { get; set; }

        public byte? BankId { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LastUpdatedDate { get; set; }


        public virtual TrPaymentHeader TrPaymentHeader { get; set; }
        public virtual DcPaymentType DcPaymentType { get; set; }
    }
}
