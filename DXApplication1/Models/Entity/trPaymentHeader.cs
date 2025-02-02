﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PointOfSale.Models
{
    public partial class TrPaymentHeader : BaseEntity
    {
        [Key]
        public Guid PaymentHeaderId { get; set; }

        [ForeignKey("TrInvoiceHeader")]
        public Guid? InvoiceHeaderId { get; set; }

        [DisplayName("Sənəd Nömrəsi")]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Sənəd Tarixi")]
        public DateTime DocumentDate { get; set; }

        [DisplayName("Sənəd Vaxtı")]
        [Column(TypeName = "time(0)")]
        public TimeSpan DocumentTime { get; set; }

        [DisplayName("Faktura Nömrəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string InvoiceNumber { get; set; }

        [DisplayName("Cari Hesab")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrAccCode { get; set; }

        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(200, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string Description { get; set; }

        [DisplayName("Şirkət")]
        public decimal CompanyCode { get; set; }

        [DisplayName("Ofis")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(5, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string OfficeCode { get; set; }

        [DisplayName("Mağaza")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(30, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string StoreCode { get; set; }

        [DisplayName("POS Terminal")]
        public short PosterminalId { get; set; }

        [DisplayName("Valyuta")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(10, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public string CurrencyCode { get; set; }

        [DisplayName("Valyuta Dərəcəsi")]
        [Required(ErrorMessage = "{0} boş buraxila bilmez \n")]
        [StringLength(60, ErrorMessage = "{0} {1} simvoldan çox ola bilməz \n")]
        public double ExchangeRate { get; set; }

        [DisplayName("Tamamlanıb")]
        public bool IsCompleted { get; set; }

        [DisplayName("Kilidlənib")]
        public bool IsLocked { get; set; }


        public virtual ICollection<TrPaymentLine> TrPaymentLines { get; set; }
        public virtual TrInvoiceHeader TrInvoiceHeader { get; set; }
    }
}
