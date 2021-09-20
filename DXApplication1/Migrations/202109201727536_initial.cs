namespace PointOfSale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.dcCurrAcc",
                c => new
                    {
                        CurrAccCode = c.String(nullable: false, maxLength: 30),
                        CurrAccTypeCode = c.Byte(nullable: false),
                        CompanyCode = c.Byte(nullable: false),
                        OfficeCode = c.String(nullable: false, maxLength: 5),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        FatherName = c.String(nullable: false, maxLength: 60),
                        FullName = c.String(maxLength: 182),
                        IdentityNum = c.String(nullable: false, maxLength: 20),
                        TaxNum = c.String(nullable: false, maxLength: 20),
                        DataLanguageCode = c.String(nullable: false, maxLength: 5),
                        CreditLimit = c.Decimal(nullable: false, storeType: "money"),
                        IsVIP = c.Boolean(nullable: false),
                        CustomerTypeCode = c.Byte(nullable: false),
                        VendorTypeCode = c.Byte(nullable: false),
                        CustomerPosDiscountRate = c.Double(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                        BonusCardNum = c.String(maxLength: 50),
                        Address = c.String(maxLength: 150),
                        PhoneNum = c.String(maxLength: 50),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CurrAccCode)
                .ForeignKey("dbo.dcCurrAccType", t => t.CurrAccTypeCode)
                .Index(t => t.CurrAccTypeCode);
            
            CreateTable(
                "dbo.dcCurrAccType",
                c => new
                    {
                        CurrAccTypeCode = c.Byte(nullable: false),
                        CurrAccTypeDescription = c.String(nullable: false, maxLength: 100),
                        IsDisabled = c.Boolean(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CurrAccTypeCode);
            
            CreateTable(
                "dbo.trInvoiceHeader",
                c => new
                    {
                        InvoiceHeaderId = c.Guid(nullable: false),
                        RelatedInvoiceId = c.Guid(),
                        ProcessCode = c.String(nullable: false, maxLength: 5),
                        DocumentNumber = c.String(nullable: false, maxLength: 30),
                        IsReturn = c.Boolean(nullable: false),
                        DocumentDate = c.DateTime(storeType: "date"),
                        DocumentTime = c.Time(nullable: false, precision: 0),
                        OperationDate = c.DateTime(nullable: false, storeType: "date"),
                        OperationTime = c.Time(nullable: false, precision: 0),
                        Description = c.String(nullable: false, maxLength: 2000),
                        CurrAccCode = c.String(maxLength: 30),
                        CompanyCode = c.String(maxLength: 10),
                        OfficeCode = c.String(nullable: false, maxLength: 10),
                        StoreCode = c.String(nullable: false, maxLength: 30),
                        WarehouseCode = c.String(nullable: false, maxLength: 10),
                        CustomsDocumentNumber = c.String(maxLength: 30),
                        POSTerminalId = c.String(nullable: false, maxLength: 30),
                        IsSuspended = c.Boolean(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsPrinted = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        FiscalPrintedState = c.Byte(nullable: false),
                        IsSalesViaInternet = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceHeaderId)
                .ForeignKey("dbo.dcCurrAcc", t => t.CurrAccCode)
                .Index(t => t.CurrAccCode);
            
            CreateTable(
                "dbo.trInvoiceLine",
                c => new
                    {
                        InvoiceLineId = c.Guid(nullable: false),
                        InvoiceHeaderId = c.Guid(nullable: false),
                        RelatedLineId = c.Guid(),
                        ProductCode = c.String(maxLength: 150),
                        Qty = c.Int(),
                        Price = c.Double(),
                        Amount = c.Decimal(storeType: "money"),
                        PosDiscount = c.Decimal(storeType: "money"),
                        DiscountCampaign = c.Decimal(storeType: "money"),
                        NetAmount = c.Decimal(storeType: "money"),
                        VatRate = c.Single(),
                        LineDescription = c.String(),
                        SalespersonCode = c.String(maxLength: 50),
                        CurrencyCode = c.String(maxLength: 10),
                        ExchangeRate = c.Double(),
                        CreatedUserName = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        LastUpdatedUserName = c.String(maxLength: 50),
                        LastUpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.InvoiceLineId)
                .ForeignKey("dbo.dcProduct", t => t.ProductCode)
                .ForeignKey("dbo.trInvoiceHeader", t => t.InvoiceHeaderId)
                .Index(t => t.InvoiceHeaderId)
                .Index(t => t.ProductCode);
            
            CreateTable(
                "dbo.dcProduct",
                c => new
                    {
                        ProductCode = c.String(nullable: false, maxLength: 150),
                        Barcode = c.String(maxLength: 50),
                        ProductTypeCode = c.Byte(),
                        UsePos = c.Boolean(),
                        PromotionCode = c.String(maxLength: 50),
                        PromotionCode2 = c.String(maxLength: 50),
                        TaxRate = c.Double(),
                        PosDiscount = c.Double(),
                        IsDisabled = c.Boolean(),
                        RetailPrice = c.Double(),
                        PurchasePrice = c.Double(),
                        WholesalePrice = c.Double(),
                        IsBlocked = c.Boolean(),
                        UseInternet = c.Boolean(),
                        ProductDescription = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.ProductCode)
                .ForeignKey("dbo.dcProductType", t => t.ProductTypeCode)
                .Index(t => t.ProductTypeCode);
            
            CreateTable(
                "dbo.dcProductType",
                c => new
                    {
                        ProductTypeCode = c.Byte(nullable: false),
                        ProductTypeDesc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductTypeCode);
            
            CreateTable(
                "dbo.dcOffice",
                c => new
                    {
                        OfficeCode = c.String(nullable: false, maxLength: 5),
                        OfficeDesc = c.String(nullable: false, maxLength: 150),
                        CompanyCode = c.Decimal(nullable: false, precision: 4, scale: 0, storeType: "numeric"),
                        IsDisabled = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OfficeCode);
            
            CreateTable(
                "dbo.dcPaymentType",
                c => new
                    {
                        PaymentTypeCode = c.Byte(nullable: false),
                        PaymentTypeDescription = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PaymentTypeCode);
            
            CreateTable(
                "dbo.dcProcess",
                c => new
                    {
                        ProcessCode = c.String(nullable: false, maxLength: 5),
                        ProcessDescription = c.String(maxLength: 200),
                        LastNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ProcessCode);
            
            CreateTable(
                "dbo.dcStore",
                c => new
                    {
                        StoreCode = c.String(nullable: false, maxLength: 50),
                        StoreDesc = c.String(nullable: false, maxLength: 150),
                        CompanyCode = c.Decimal(nullable: false, precision: 4, scale: 0, storeType: "numeric"),
                        IsDisabled = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StoreCode);
            
            CreateTable(
                "dbo.dcTerminal",
                c => new
                    {
                        TerminalCode = c.String(nullable: false, maxLength: 50),
                        TerminalDesc = c.String(nullable: false, maxLength: 150),
                        IsDisabled = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TerminalCode);
            
            CreateTable(
                "dbo.dcWarehouse",
                c => new
                    {
                        WarehouseCode = c.String(nullable: false, maxLength: 50),
                        WarehouseDesc = c.String(nullable: false, maxLength: 150),
                        WarehouseTypeCode = c.Byte(nullable: false),
                        OfficeCode = c.String(nullable: false, maxLength: 5),
                        StoreCode = c.String(nullable: false, maxLength: 50),
                        PermitNegativeStock = c.Boolean(nullable: false),
                        WarnNegativeStock = c.Boolean(nullable: false),
                        ControlStockLevel = c.Boolean(nullable: false),
                        WarnStockLevelRate = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                        RowGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseCode);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.trPaymentHeader",
                c => new
                    {
                        PaymentHeaderID = c.Guid(nullable: false),
                        InvoiceHeaderID = c.Guid(),
                        DocumentNumber = c.String(nullable: false, maxLength: 30),
                        DocumentDate = c.DateTime(nullable: false, storeType: "date"),
                        DocumentTime = c.Time(nullable: false, precision: 0),
                        InvoiceNumber = c.String(nullable: false, maxLength: 30),
                        CurrAccCode = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 200),
                        CompanyCode = c.Decimal(nullable: false, precision: 4, scale: 0, storeType: "numeric"),
                        OfficeCode = c.String(nullable: false, maxLength: 5),
                        StoreCode = c.String(nullable: false, maxLength: 30),
                        POSTerminalID = c.Short(nullable: false),
                        CurrencyCode = c.String(nullable: false, maxLength: 10),
                        ExchangeRate = c.Double(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentHeaderID);
            
            CreateTable(
                "dbo.trPaymentLine",
                c => new
                    {
                        PaymentLineID = c.Guid(nullable: false),
                        PaymentHeaderID = c.Guid(nullable: false),
                        PaymentTypeCode = c.Byte(nullable: false),
                        Payment = c.Decimal(nullable: false, storeType: "money"),
                        LineDescription = c.String(nullable: false, maxLength: 200),
                        CurrencyCode = c.String(nullable: false, maxLength: 10),
                        ExchangeRate = c.Double(nullable: false),
                        BankID = c.Byte(),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentLineID);
            
            CreateTable(
                "dbo.trShipmentHeader",
                c => new
                    {
                        ShipmentHeaderID = c.Guid(nullable: false),
                        ShipTypeCode = c.Byte(nullable: false),
                        ProcessCode = c.String(nullable: false, maxLength: 5),
                        ShippingNumber = c.String(nullable: false, maxLength: 30),
                        ShippingDate = c.DateTime(nullable: false, storeType: "date"),
                        ShippingTime = c.Time(nullable: false, precision: 0),
                        OperationDate = c.DateTime(nullable: false, storeType: "date"),
                        OperationTime = c.Time(nullable: false, precision: 0),
                        CustomsDocumentNumber = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 200),
                        CurrAccCode = c.String(nullable: false, maxLength: 30),
                        ShippingPostalAddressID = c.Guid(),
                        CompanyCode = c.Decimal(nullable: false, precision: 4, scale: 0, storeType: "numeric"),
                        OfficeCode = c.String(nullable: false, maxLength: 5),
                        StoreCode = c.String(nullable: false, maxLength: 30),
                        WarehouseCode = c.String(nullable: false, maxLength: 10),
                        ToWarehouseCode = c.String(nullable: false, maxLength: 10),
                        IsOrderBase = c.Boolean(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        IsPrinted = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        IsTransferApproved = c.Boolean(nullable: false),
                        TransferApprovedDate = c.DateTime(nullable: false, storeType: "date"),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentHeaderID);
            
            CreateTable(
                "dbo.trShipmentLine",
                c => new
                    {
                        ShipmentLineID = c.Guid(nullable: false),
                        ShipmentHeaderID = c.Guid(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        ItemTypeCode = c.Byte(nullable: false),
                        ProductCode = c.String(nullable: false, maxLength: 30),
                        ColorCode = c.String(nullable: false, maxLength: 10),
                        ProductDimensionCode = c.String(nullable: false, maxLength: 10),
                        Qty = c.Double(nullable: false),
                        SalespersonCode = c.String(nullable: false, maxLength: 10),
                        LineDescription = c.String(nullable: false, maxLength: 200),
                        UsedBarcode = c.String(nullable: false, maxLength: 30),
                        CurrencyCode = c.String(nullable: false, maxLength: 10),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        CreatedUserName = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        LastUpdatedUserName = c.String(nullable: false, maxLength: 20),
                        LastUpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentLineID)
                .ForeignKey("dbo.trShipmentHeader", t => t.ShipmentHeaderID)
                .Index(t => t.ShipmentHeaderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.trShipmentLine", "ShipmentHeaderID", "dbo.trShipmentHeader");
            DropForeignKey("dbo.trInvoiceLine", "InvoiceHeaderId", "dbo.trInvoiceHeader");
            DropForeignKey("dbo.trInvoiceLine", "ProductCode", "dbo.dcProduct");
            DropForeignKey("dbo.dcProduct", "ProductTypeCode", "dbo.dcProductType");
            DropForeignKey("dbo.trInvoiceHeader", "CurrAccCode", "dbo.dcCurrAcc");
            DropForeignKey("dbo.dcCurrAcc", "CurrAccTypeCode", "dbo.dcCurrAccType");
            DropIndex("dbo.trShipmentLine", new[] { "ShipmentHeaderID" });
            DropIndex("dbo.dcProduct", new[] { "ProductTypeCode" });
            DropIndex("dbo.trInvoiceLine", new[] { "ProductCode" });
            DropIndex("dbo.trInvoiceLine", new[] { "InvoiceHeaderId" });
            DropIndex("dbo.trInvoiceHeader", new[] { "CurrAccCode" });
            DropIndex("dbo.dcCurrAcc", new[] { "CurrAccTypeCode" });
            DropTable("dbo.trShipmentLine");
            DropTable("dbo.trShipmentHeader");
            DropTable("dbo.trPaymentLine");
            DropTable("dbo.trPaymentHeader");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.dcWarehouse");
            DropTable("dbo.dcTerminal");
            DropTable("dbo.dcStore");
            DropTable("dbo.dcProcess");
            DropTable("dbo.dcPaymentType");
            DropTable("dbo.dcOffice");
            DropTable("dbo.dcProductType");
            DropTable("dbo.dcProduct");
            DropTable("dbo.trInvoiceLine");
            DropTable("dbo.trInvoiceHeader");
            DropTable("dbo.dcCurrAccType");
            DropTable("dbo.dcCurrAcc");
        }
    }
}
