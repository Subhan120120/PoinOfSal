using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PointOfSale
{
    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=efConString")
        {
        }

        public virtual DbSet<dcCurrAcc> dcCurrAccs { get; set; }
        public virtual DbSet<dcCurrAccType> dcCurrAccTypes { get; set; }
        public virtual DbSet<dcOffice> dcOffices { get; set; }
        public virtual DbSet<dcPaymentType> dcPaymentTypes { get; set; }
        public virtual DbSet<dcProcess> dcProcesses { get; set; }
        public virtual DbSet<dcProduct> dcProducts { get; set; }
        public virtual DbSet<dcProductType> dcProductTypes { get; set; }
        public virtual DbSet<dcStore> dcStores { get; set; }
        public virtual DbSet<dcTerminal> dcTerminals { get; set; }
        public virtual DbSet<dcWarehouse> dcWarehouses { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<trInvoiceHeader> trInvoiceHeaders { get; set; }
        public virtual DbSet<trInvoiceLine> trInvoiceLines { get; set; }
        public virtual DbSet<trPaymentHeader> trPaymentHeaders { get; set; }
        public virtual DbSet<trPaymentLine> trPaymentLines { get; set; }
        public virtual DbSet<trShipmentHeader> trShipmentHeaders { get; set; }
        public virtual DbSet<trShipmentLine> trShipmentLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dcCurrAcc>()
                .Property(e => e.CreditLimit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<dcCurrAccType>()
                .HasMany(e => e.dcCurrAccs)
                .WithRequired(e => e.dcCurrAccType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dcOffice>()
                .Property(e => e.CompanyCode)
                .HasPrecision(4, 0);

            modelBuilder.Entity<dcStore>()
                .Property(e => e.CompanyCode)
                .HasPrecision(4, 0);

            modelBuilder.Entity<trInvoiceHeader>()
                .Property(e => e.DocumentTime)
                .HasPrecision(0);

            modelBuilder.Entity<trInvoiceHeader>()
                .Property(e => e.OperationTime)
                .HasPrecision(0);

            modelBuilder.Entity<trInvoiceHeader>()
                .HasMany(e => e.trInvoiceLines)
                .WithRequired(e => e.trInvoiceHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trInvoiceLine>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<trInvoiceLine>()
                .Property(e => e.NetAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<trPaymentHeader>()
                .Property(e => e.DocumentTime)
                .HasPrecision(0);

            modelBuilder.Entity<trPaymentHeader>()
                .Property(e => e.CompanyCode)
                .HasPrecision(4, 0);

            modelBuilder.Entity<trPaymentLine>()
                .Property(e => e.Payment)
                .HasPrecision(19, 4);

            modelBuilder.Entity<trShipmentHeader>()
                .Property(e => e.ShippingTime)
                .HasPrecision(0);

            modelBuilder.Entity<trShipmentHeader>()
                .Property(e => e.OperationTime)
                .HasPrecision(0);

            modelBuilder.Entity<trShipmentHeader>()
                .Property(e => e.CompanyCode)
                .HasPrecision(4, 0);

            modelBuilder.Entity<trShipmentHeader>()
                .HasMany(e => e.trShipmentLines)
                .WithRequired(e => e.trShipmentHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<trShipmentLine>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
