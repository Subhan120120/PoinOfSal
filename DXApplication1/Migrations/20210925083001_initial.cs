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
                name: "DcCurrAccTypes",
                columns: table => new
                {
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CurrAccTypeDescription = table.Column<string>(maxLength: 100, nullable: false, defaultValueSql: "space(0)"),
                    IsDisabled = table.Column<bool>(nullable: false),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccTypes", x => x.CurrAccTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcOffices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false),
                    OfficeDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcOffices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcPaymentTypes",
                columns: table => new
                {
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    PaymentTypeDescription = table.Column<string>(maxLength: 100, nullable: true, defaultValueSql: "space(0)"),
                    DcPaymentTypePaymentTypeCode = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcPaymentTypes", x => x.PaymentTypeCode);
                    table.ForeignKey(
                        name: "FK_DcPaymentTypes_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                        column: x => x.DcPaymentTypePaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcProcesses",
                columns: table => new
                {
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false),
                    ProcessDescription = table.Column<string>(maxLength: 200, nullable: true, defaultValueSql: "space(0)"),
                    LastNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProcesses", x => x.ProcessCode);
                });

            migrationBuilder.CreateTable(
                name: "DcProductTypes",
                columns: table => new
                {
                    ProductTypeCode = table.Column<byte>(nullable: false),
                    ProductTypeDesc = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProductTypes", x => x.ProductTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "DcStores",
                columns: table => new
                {
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false),
                    StoreDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(type: "numeric(4, 0)", nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcStores", x => x.StoreCode);
                });

            migrationBuilder.CreateTable(
                name: "DcTerminals",
                columns: table => new
                {
                    TerminalCode = table.Column<string>(maxLength: 50, nullable: false),
                    TerminalDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcTerminals", x => x.TerminalCode);
                });

            migrationBuilder.CreateTable(
                name: "DcWarehouses",
                columns: table => new
                {
                    WarehouseCode = table.Column<string>(maxLength: 50, nullable: false),
                    WarehouseDesc = table.Column<string>(maxLength: 150, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseTypeCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "space(0)"),
                    PermitNegativeStock = table.Column<bool>(nullable: false),
                    WarnNegativeStock = table.Column<bool>(nullable: false),
                    ControlStockLevel = table.Column<bool>(nullable: false),
                    WarnStockLevelRate = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RowGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcWarehouses", x => x.WarehouseCode);
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
                name: "TrShipmentHeaders",
                columns: table => new
                {
                    ShipmentHeaderId = table.Column<Guid>(nullable: false),
                    ShipTypeCode = table.Column<byte>(nullable: false),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    ShippingNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    ShippingDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    ShippingTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "'00:00:00'"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "'00:00:00'"),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "space(0)"),
                    Description = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    ShippingPostalAddressId = table.Column<Guid>(nullable: true, defaultValueSql: "space(0)"),
                    CompanyCode = table.Column<decimal>(maxLength: 10, nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    ToWarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsOrderBase = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsPrinted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsTransferApproved = table.Column<bool>(nullable: false),
                    TransferApprovedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "space(0)"),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentHeaders", x => x.ShipmentHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "DcCurrAccs",
                columns: table => new
                {
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false),
                    CurrAccTypeCode = table.Column<byte>(nullable: false),
                    CompanyCode = table.Column<byte>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false, defaultValueSql: "space(0)"),
                    LastName = table.Column<string>(maxLength: 60, nullable: false, defaultValueSql: "space(0)"),
                    FatherName = table.Column<string>(maxLength: 60, nullable: false, defaultValueSql: "space(0)"),
                    IdentityNum = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "space(0)"),
                    TaxNum = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "space(0)"),
                    DataLanguageCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "0"),
                    IsVIP = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CustomerTypeCode = table.Column<byte>(nullable: false),
                    VendorTypeCode = table.Column<byte>(nullable: false),
                    CustomerPosDiscountRate = table.Column<double>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    RowGuid = table.Column<Guid>(nullable: false),
                    BonusCardNum = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    Address = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "space(0)"),
                    PhoneNum = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    BirthDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcCurrAccs", x => x.CurrAccCode);
                    table.ForeignKey(
                        name: "FK_DcCurrAccs_DcCurrAccTypes_CurrAccTypeCode",
                        column: x => x.CurrAccTypeCode,
                        principalTable: "DcCurrAccTypes",
                        principalColumn: "CurrAccTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DcProducts",
                columns: table => new
                {
                    ProductCode = table.Column<string>(maxLength: 30, nullable: false),
                    Barcode = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    ProductTypeCode = table.Column<byte>(nullable: true),
                    UsePos = table.Column<bool>(nullable: true),
                    PromotionCode = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    PromotionCode2 = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    TaxRate = table.Column<double>(nullable: true),
                    PosDiscount = table.Column<double>(nullable: true),
                    IsDisabled = table.Column<bool>(nullable: true),
                    RetailPrice = table.Column<double>(nullable: true),
                    PurchasePrice = table.Column<double>(nullable: true),
                    WholesalePrice = table.Column<double>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: true),
                    UseInternet = table.Column<bool>(nullable: true),
                    ProductDescription = table.Column<string>(maxLength: 150, nullable: true, defaultValueSql: "space(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcProducts", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                        column: x => x.ProductTypeCode,
                        principalTable: "DcProductTypes",
                        principalColumn: "ProductTypeCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrShipmentLines",
                columns: table => new
                {
                    ShipmentLineId = table.Column<Guid>(nullable: false),
                    ShipmentHeaderId = table.Column<Guid>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ItemTypeCode = table.Column<byte>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true, defaultValueSql: "space(0)"),
                    ColorCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ProductDimensionCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    Qty = table.Column<double>(nullable: false),
                    SalespersonCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    UsedBarcode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    Price = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrShipmentLines", x => x.ShipmentLineId);
                    table.ForeignKey(
                        name: "FK_TrShipmentLines_TrShipmentHeaders_ShipmentHeaderId",
                        column: x => x.ShipmentHeaderId,
                        principalTable: "TrShipmentHeaders",
                        principalColumn: "ShipmentHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceHeaders",
                columns: table => new
                {
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    RelatedInvoiceId = table.Column<Guid>(nullable: true),
                    ProcessCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    DocumentNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsReturn = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "'00:00:00'"),
                    OperationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "getdate()"),
                    OperationTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "'00:00:00'"),
                    Description = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "space(0)"),
                    OfficeCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    WarehouseCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    CustomsDocumentNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    PosTerminalId = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    IsSuspended = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsCompleted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsPrinted = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    IsLocked = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    FiscalPrintedState = table.Column<byte>(nullable: false, defaultValueSql: "space(0)"),
                    IsSalesViaInternet = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceHeaders", x => x.InvoiceHeaderId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                        column: x => x.CurrAccCode,
                        principalTable: "DcCurrAccs",
                        principalColumn: "CurrAccCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrInvoiceLines",
                columns: table => new
                {
                    InvoiceLineId = table.Column<Guid>(nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(nullable: false),
                    RelatedLineId = table.Column<Guid>(nullable: true),
                    ProductCode = table.Column<string>(maxLength: 30, nullable: true, defaultValueSql: "space(0)"),
                    Qty = table.Column<int>(nullable: true, defaultValueSql: "1"),
                    Price = table.Column<double>(nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    PosDiscount = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    DiscountCampaign = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    NetAmount = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "0"),
                    VatRate = table.Column<float>(nullable: true),
                    LineDescription = table.Column<string>(nullable: true),
                    SalespersonCode = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: true, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(nullable: true),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrInvoiceLines", x => x.InvoiceLineId);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentHeaders",
                columns: table => new
                {
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    InvoiceHeaderId = table.Column<Guid>(nullable: true, defaultValueSql: "space(0)"),
                    DocumentNumber = table.Column<string>(nullable: true, defaultValueSql: "space(0)"),
                    DocumentDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    DocumentTime = table.Column<TimeSpan>(type: "time(0)", nullable: false, defaultValueSql: "'00:00:00'"),
                    InvoiceNumber = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    CurrAccCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    Description = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "'00:00:00'"),
                    CompanyCode = table.Column<decimal>(nullable: false),
                    OfficeCode = table.Column<string>(maxLength: 5, nullable: false, defaultValueSql: "space(0)"),
                    StoreCode = table.Column<string>(maxLength: 30, nullable: false, defaultValueSql: "space(0)"),
                    PosterminalId = table.Column<short>(nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentHeaders", x => x.PaymentHeaderId);
                    table.ForeignKey(
                        name: "FK_TrPaymentHeaders_TrInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "TrInvoiceHeaders",
                        principalColumn: "InvoiceHeaderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrPaymentLines",
                columns: table => new
                {
                    PaymentLineId = table.Column<Guid>(nullable: false),
                    PaymentHeaderId = table.Column<Guid>(nullable: false),
                    PaymentTypeCode = table.Column<byte>(nullable: false),
                    Payment = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    LineDescription = table.Column<string>(maxLength: 200, nullable: false, defaultValueSql: "space(0)"),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "space(0)"),
                    ExchangeRate = table.Column<double>(nullable: false),
                    BankId = table.Column<byte>(nullable: true),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrPaymentLines", x => x.PaymentLineId);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_TrPaymentHeaders_PaymentHeaderId",
                        column: x => x.PaymentHeaderId,
                        principalTable: "TrPaymentHeaders",
                        principalColumn: "PaymentHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                        column: x => x.PaymentTypeCode,
                        principalTable: "DcPaymentTypes",
                        principalColumn: "PaymentTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccTypeCode",
                table: "DcCurrAccs",
                column: "CurrAccTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes",
                column: "DcPaymentTypePaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrAccCode",
                table: "TrInvoiceHeaders",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeaderId",
                table: "TrInvoiceLines",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentHeaders_InvoiceHeaderId",
                table: "TrPaymentHeaders",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentHeaderId",
                table: "TrPaymentLines",
                column: "PaymentHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TrPaymentLines_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentHeaderID",
                table: "TrShipmentLines",
                column: "ShipmentHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

            migrationBuilder.DropTable(
                name: "DcOffices");

            migrationBuilder.DropTable(
                name: "DcProcesses");

            migrationBuilder.DropTable(
                name: "DcStores");

            migrationBuilder.DropTable(
                name: "DcTerminals");

            migrationBuilder.DropTable(
                name: "DcWarehouses");

            migrationBuilder.DropTable(
                name: "sysdiagrams");

            migrationBuilder.DropTable(
                name: "TrInvoiceLines");

            migrationBuilder.DropTable(
                name: "TrPaymentLines");

            migrationBuilder.DropTable(
                name: "TrShipmentLines");

            migrationBuilder.DropTable(
                name: "DcProducts");

            migrationBuilder.DropTable(
                name: "TrPaymentHeaders");

            migrationBuilder.DropTable(
                name: "DcPaymentTypes");

            migrationBuilder.DropTable(
                name: "TrShipmentHeaders");

            migrationBuilder.DropTable(
                name: "DcProductTypes");

            migrationBuilder.DropTable(
                name: "TrInvoiceHeaders");

            migrationBuilder.DropTable(
                name: "DcCurrAccs");

            migrationBuilder.DropTable(
                name: "DcCurrAccTypes");
        }
    }
}
