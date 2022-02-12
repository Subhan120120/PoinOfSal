using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Cari Hesab Kodu")]
        public string CurrAccCode { get; set; }

        [ForeignKey("DcCurrAccType")]
        [DisplayName("Cari Hesab Tipi Kodu")]
        public byte CurrAccTypeCode { get; set; }

        [DisplayName("Şirkət")]
        public byte CompanyCode { get; set; }

        [DisplayName("Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string LastName { get; set; }

        [DisplayName("Ata Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string FatherName { get; set; }

        [Required]
        [DisplayName("Şifrə")]
        public string Password { get; set; }

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
        public virtual ICollection<TrCurrAccRole> TrCurrAccRole { get; set; }
    }
}
