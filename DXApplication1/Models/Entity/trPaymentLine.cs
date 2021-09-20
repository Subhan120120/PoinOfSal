namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trPaymentLine")]
    public partial class trPaymentLine
    {
        [Key]
        public Guid PaymentLineID { get; set; }

        public Guid PaymentHeaderID { get; set; }

        public byte PaymentTypeCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Payment { get; set; }

        [Required]
        [StringLength(200)]
        public string LineDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string CurrencyCode { get; set; }

        public double ExchangeRate { get; set; }

        public byte? BankID { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
