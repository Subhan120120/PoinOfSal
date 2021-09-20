namespace PointOfSale
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dcCurrAcc")]
    public partial class dcCurrAcc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dcCurrAcc()
        {
            trInvoiceHeaders = new HashSet<trInvoiceHeader>();
        }

        public byte CurrAccTypeCode { get; set; }

        [Key]
        [StringLength(30)]
        public string CurrAccCode { get; set; }

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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(182)]
        public string FullName { get; set; }

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

        public bool IsVIP { get; set; }

        public byte CustomerTypeCode { get; set; }

        public byte VendorTypeCode { get; set; }

        public double CustomerPosDiscountRate { get; set; }

        public bool IsDisabled { get; set; }

        [Required]
        [StringLength(20)]
        public string CreatedUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(20)]
        public string LastUpdatedUserName { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public Guid RowGuid { get; set; }

        [StringLength(50)]
        public string BonusCardNum { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNum { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual dcCurrAccType dcCurrAccType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trInvoiceHeader> trInvoiceHeaders { get; set; }
    }
}
