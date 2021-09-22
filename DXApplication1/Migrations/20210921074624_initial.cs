using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccType",
                columns: table => new
                {
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CurrAccTypeDescription = table.Column<string>(maxLength: 100, nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcCurrAccType", x => x.CurrAccTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcOffice",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    OfficeDesc = table.Column<string>(maxLength: 150, nullable: false),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcOffice", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcPaymentType",
                columns: table => new
                {
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    PaymentTypeDescription = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcPaymentType", x => x.PaymentTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProcess",
                columns: table => new
                {
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false),
                    ProcessDescription = table.Column<string>(maxLength: 200, nullable: true),
                    LastNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcProcess", x => x.ProcessCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProductType",
                columns: table => new
                {
                    ProductTypeCode = table.Column<byte>(nullable: false),
                    ProductTypeDesc = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcProductType", x => x.ProductTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcStore",
                columns: table => new
                {
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false),
                    StoreDesc = table.Column<string>(maxLength: 150, nullable: false),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcStore", x => x.StoreCode);
                });

            migrationBuilder.CreateTable(
                name: "DcTerminal",
                columns: table => new
                {
                    TerminalCode = table.Column<string>(maxLength: 50, nullable: false),
                    TerminalDesc = table.Column<string>(maxLength: 150, nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcTerminal", x => x.TerminalCode);
                });

            migrationBuilder.CreateTable(
                name: "DcWarehouse",
                columns: table => new
                {
                    WarehouseCode = table.Column<string>(maxLength: 50, nullable: false),
                    WarehouseDesc = table.Column<string>(maxLength: 150, nullable: false),
                    WarehouseTypeCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false),
                    PermitNegativeStock = table.Column<bool>(nullable: false),
                    WarnNegativeStock = table.Column<bool>(nullable: false),
                    ControlStockLevel = table.Column<bool>(nullable: false),
                    WarnStockLevelRate = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcWarehouse", x => x.WarehouseCode);
                });

            migrationBuilder.CreateTable(
                name: "sysdiagrams",
                columns: table => new
                {
                    diagram_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    principal_id = table.Column<int>(nullable: false),
                    version = table.Column<int>(nullable: true),
                    definition = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.sysdiagrams", x => x.diagram_id);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentHeader",
                columns: table => new
                {
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(nullable: true),
                    DocumentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 30, nullable: false),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false),
                    POSTerminalID = table.Column<short>(nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<double>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrPaymentHeader", x => x.PaymentHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentLine",
                columns: table => new
                {
                    PaymentLineId = table.Column<Guid>(nullable: false),
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    Payment = table.Column<decimal>(type: "money", nullable: false),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<double>(nullable: false),
                    BankID = table.Column<byte>(nullable: true),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrPaymentLine", x => x.PaymentLineId);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentHeader",
                columns: table => new
                {
                    ShipmentHeaderID = table.Column<Guid>(nullable: false),
                    ShipTypeCode = table.Column<byte>(nullable: false),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false),
                    ShippingNumber = table.Column<string>(maxLength: 30, nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippingTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    ShippingPostalAddressID = table.Column<Guid>(nullable: true),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false),
                    WarehouseCode = table.Column<string>(maxLength: 10, nullable: false),
                    ToWarehouseCode = table.Column<string>(maxLength: 10, nullable: false),
                    IsOrderBase = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsPrinted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsTransferApproved = table.Column<bool>(nullable: false),
                    TransferApprovedDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrShipmentHeader", x => x.ShipmentHeaderID);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAcc",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CompanyCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    FatherName = table.Column<string>(maxLength: 60, nullable: false),
                    FullName = table.Column<string>(maxLength: 182, nullable: true),
                    IdentityNum = table.Column<string>(maxLength: 20, nullable: false),
                    TaxNum = table.Column<string>(maxLength: 20, nullable: false),
                    DataLanguageCode = table.Column<string>(maxLength: 5, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: false),
                    IsVIP = table.Column<bool>(nullable: false),
                    CustomerTypeCode = table.Column<byte>(nullable: false),
                    VendorTypeCode = table.Column<byte>(nullable: false),
                    CustomerPosDiscountRate = table.Column<double>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false),
                    BonusCardNum = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNum = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcCurrAcc", x => x.CurrAccCode);
                    table.ForeignKey(
                        name: "FK_dbo.DcCurrAcc_dbo.DcCurrAccType_CurrAccTypeCode",
                        column: x => x.CurrAccTypeCode,
                        principalTable: "DcCurrAccType",
                        principalColumn: "CurrAccTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcProduct",
                columns: table => new
                {
                    ProductCode = table.Column<string>(maxLength: 150, nullable: false),
                    Barcode = table.Column<string>(maxLength: 50, nullable: true),
                    ProductTypeCode = table.Column<byte>(nullable: true),
                    UsePos = table.Column<bool>(nullable: true),
                    PromotionCode = table.Column<string>(maxLength: 50, nullable: true),
                    PromotionCode2 = table.Column<string>(maxLength: 50, nullable: true),
                    TaxRate = table.Column<double>(nullable: true),
                    PosDiscount = table.Column<double>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    RetailPrice = table.Column<double>(nullable: true),
                    PurchasePrice = table.Column<double>(nullable: true),
                    WholesalePrice = table.Column<double>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: true),
                    UseInternet = table.Column<bool>(nullable: true),
                    ProductDescription = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.DcProduct", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_dbo.DcProduct_dbo.DcProductType_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "DcProductType",
                        principalColumn: "ProductTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentLine",
                columns: table => new
                {
                    ShipmentLineID = table.Column<Guid>(nullable: false),
                    ShipmentHeaderID = table.Column<Guid>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ItemTypeCode = table.Column<byte>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 30, nullable: false),
                    ColorCode = table.Column<string>(maxLength: 10, nullable: false),
                    ProductDimensionCode = table.Column<string>(maxLength: 10, nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    SalespersonCode = table.Column<string>(maxLength: 10, nullable: false),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false),
                    UsedBarcode = table.Column<string>(maxLength: 30, nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrShipmentLine", x => x.ShipmentLineID);
                    table.ForeignKey(
                        name: "FK_dbo.TrShipmentLine_dbo.trShipmentHeader_ShipmentHeaderID",
                        column: x => x.ShipmentHeaderID,
                        principalTable: "TrShipmentHeader",
                        principalColumn: "ShipmentHeaderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceHeader",
                columns: table => new
                {
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    RelatedInvoiceId = table.Column<Guid>(nullable: true),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false),
                    DocumentNumber = table.Column<string>(maxLength: 30, nullable: false),
                    IsReturn = table.Column<bool>(nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: true),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: true),
                    CompanyCode = table.Column<string>(maxLength: 10, nullable: true),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false),
                    WarehouseCode = table.Column<string>(maxLength: 10, nullable: false),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: true),
                    POSTerminalId = table.Column<string>(maxLength: 30, nullable: false),
                    IsSuspended = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsPrinted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    FiscalPrintedState = table.Column<byte>(nullable: false),
                    IsSalesViaInternet = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrInvoiceHeader", x => x.InvoiceHeaderId);
                    table.ForeignKey(
                        name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAcc",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLine",
                columns: table => new
                {
                    InvoiceLineId = table.Column<Guid>(nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    RelatedLineId = table.Column<Guid>(nullable: true),
                    ProductCode = table.Column<string>(maxLength: 150, nullable: true),
                    Qty = table.Column<int>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    PosDiscount = table.Column<decimal>(type: "money", nullable: true),
                    DiscountCampaign = table.Column<decimal>(type: "money", nullable: true),
                    NetAmount = table.Column<decimal>(type: "money", nullable: true),
                    VatRate = table.Column<float>(nullable: true),
                    LineDescription = table.Column<string>(nullable: true),
                    SalespersonCode = table.Column<string>(maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: true),
                    ExchangeRate = table.Column<double>(nullable: true),
                    CreatedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastUpdatedUserName = table.Column<string>(maxLength: 50, nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TrInvoiceLine", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_dbo.TrInvoiceLine_dbo.TrInvoiceHeader_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeader",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dbo.TrInvoiceLine_dbo.DcProduct_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProduct",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccTypeCode",
                table: "DcCurrAcc",
                column: "CurrAccTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeCode",
                table: "DcProduct",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderId",
                table: "TrInvoiceLine",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCode",
                table: "TrInvoiceLine",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentHeaderID",
                table: "TrShipmentLine",
                column: "ShipmentHeaderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "DcOffice");

            migrationBuilder.DropTable(
                name: "DcPaymentType");

            migrationBuilder.DropTable(
                name: "DcProcess");

            migrationBuilder.DropTable(
                name: "DcStore");

            migrationBuilder.DropTable(
                name: "DcTerminal");

            migrationBuilder.DropTable(
                name: "DcWarehouse");

            migrationBuilder.DropTable(
                name: "sysdiagrams");

            migrationBuilder.DropTable(
                name: "TrInvoiceLine");

            migrationBuilder.DropTable(
                name: "TrPaymentHeader");

            migrationBuilder.DropTable(
                name: "TrPaymentLine");

            migrationBuilder.DropTable(
                name: "TrShipmentLine");

            migrationBuilder.DropTable(
                name: "TrInvoiceHeader");

            migrationBuilder.DropTable(
                name: "DcProduct");

            migrationBuilder.DropTable(
                name: "TrShipmentHeader");

            migrationBuilder.DropTable(
                name: "DcCurrAcc");

            migrationBuilder.DropTable(
                name: "DcProductType");

            migrationBuilder.DropTable(
                name: "DcCurrAccType");
        }
    }
}
