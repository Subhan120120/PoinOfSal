using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    //[Index(nameof(CurrAccTypeCode))]
    public partial class DcCurrAcc : BaseEntity
    {
        public DcCurrAcc()
        {
            TrInvoiceHeaders = new HashSet<TrInvoiceHeader>();
        }

        [Key]
        [StringLength(30)]
        public string CurrAccCode { get; set; }

        [ForeignKey("DcCurrAccType")]
        public byte CurrAccTypeCode { get; set; }

        public byte CompanyCode { get; set; }

        [Required]
        [StringLength(5)]
        public string OfficeCode { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Required]
        [StringLength(60)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(20)]
        public string IdentityNum { get; set; }

        [Required]
        [StringLength(20)]
        public string TaxNum { get; set; }
        
        [Required]
        [StringLength(5)]
        public string DataLanguageCode { get; set; }

        [Column(TypeName = "money")]
        public decimal CreditLimit { get; set; }

        [Column("IsVIP")]
        public bool IsVip { get; set; }
        public byte CustomerTypeCode { get; set; }
        public byte VendorTypeCode { get; set; }
        public double CustomerPosDiscountRate { get; set; }
        public bool IsDisabled { get; set; }

        public Guid RowGuid { get; set; }

        [StringLength(50)]
        public string BonusCardNum { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public virtual DcCurrAccType DcCurrAccType { get; set; }
        public virtual ICollection<TrInvoiceHeader> TrInvoiceHeaders { get; set; }
    }
}
