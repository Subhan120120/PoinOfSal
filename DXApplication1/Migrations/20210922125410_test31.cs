using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.DcCurrAcc_dbo.DcCurrAccType_CurrAccTypeCode",
                table: "DcCurrAcc");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.DcProduct_dbo.DcProductType_ProductTypeCode",
                table: "DcProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrShipmentLine_dbo.trShipmentHeader_ShipmentHeaderID",
                table: "TrShipmentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.TrShipmentLine",
                table: "TrShipmentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.TrShipmentHeader",
                table: "TrShipmentHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.TrPaymentLine",
                table: "TrPaymentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.TrPaymentHeader",
                table: "TrPaymentHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcWarehouse",
                table: "DcWarehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcTerminal",
                table: "DcTerminal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcStore",
                table: "DcStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcProductType",
                table: "DcProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcProcess",
                table: "DcProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcPaymentType",
                table: "DcPaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcOffice",
                table: "DcOffice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcCurrAccType",
                table: "DcCurrAccType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcCurrAcc",
                table: "DcCurrAcc");

            migrationBuilder.AddColumn<string>(
                name: "CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrShipmentLine",
                table: "TrShipmentLine",
                column: "ShipmentLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrShipmentHeader",
                table: "TrShipmentHeader",
                column: "ShipmentHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrPaymentLine",
                table: "TrPaymentLine",
                column: "PaymentLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrPaymentHeader",
                table: "TrPaymentHeader",
                column: "PaymentHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcWarehouse",
                table: "DcWarehouse",
                column: "WarehouseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcTerminal",
                table: "DcTerminal",
                column: "TerminalCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcStore",
                table: "DcStore",
                column: "StoreCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcProductType",
                table: "DcProductType",
                column: "ProductTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcProcess",
                table: "DcProcess",
                column: "ProcessCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcPaymentType",
                table: "DcPaymentType",
                column: "PaymentTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcOffice",
                table: "DcOffice",
                column: "OfficeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcCurrAccType",
                table: "DcCurrAccType",
                column: "CurrAccTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcCurrAcc",
                table: "DcCurrAcc",
                column: "CurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceHeader_CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCodeNavigationCurrAccCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcProduct_ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct",
                column: "ProductTypeCodeNavigationProductTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_DcCurrAcc_CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc",
                column: "CurrAccTypeCodeNavigationCurrAccTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcCurrAcc_DcCurrAccType_CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc",
                column: "CurrAccTypeCodeNavigationCurrAccTypeCode",
                principalTable: "DcCurrAccType",
                principalColumn: "CurrAccTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DcProduct_DcProductType_ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct",
                column: "ProductTypeCodeNavigationProductTypeCode",
                principalTable: "DcProductType",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeader_DcCurrAcc_CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCodeNavigationCurrAccCode",
                principalTable: "DcCurrAcc",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrShipmentLine_TrShipmentHeader_ShipmentHeaderId",
                table: "TrShipmentLine",
                column: "ShipmentHeaderId",
                principalTable: "TrShipmentHeader",
                principalColumn: "ShipmentHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcCurrAcc_DcCurrAccType_CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc");

            migrationBuilder.DropForeignKey(
                name: "FK_DcProduct_DcProductType_ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeader_DcCurrAcc_CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_TrShipmentLine_TrShipmentHeader_ShipmentHeaderId",
                table: "TrShipmentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrShipmentLine",
                table: "TrShipmentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrShipmentHeader",
                table: "TrShipmentHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrPaymentLine",
                table: "TrPaymentLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrPaymentHeader",
                table: "TrPaymentHeader");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceHeader_CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcWarehouse",
                table: "DcWarehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcTerminal",
                table: "DcTerminal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcStore",
                table: "DcStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProductType",
                table: "DcProductType");

            migrationBuilder.DropIndex(
                name: "IX_DcProduct_ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProcess",
                table: "DcProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcPaymentType",
                table: "DcPaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcOffice",
                table: "DcOffice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcCurrAccType",
                table: "DcCurrAccType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcCurrAcc",
                table: "DcCurrAcc");

            migrationBuilder.DropIndex(
                name: "IX_DcCurrAcc_CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc");

            migrationBuilder.DropColumn(
                name: "CurrAccCodeNavigationCurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.DropColumn(
                name: "ProductTypeCodeNavigationProductTypeCode",
                table: "DcProduct");

            migrationBuilder.DropColumn(
                name: "CurrAccTypeCodeNavigationCurrAccTypeCode",
                table: "DcCurrAcc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TrShipmentLine",
                table: "TrShipmentLine",
                column: "ShipmentLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TrShipmentHeader",
                table: "TrShipmentHeader",
                column: "ShipmentHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TrPaymentLine",
                table: "TrPaymentLine",
                column: "PaymentLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TrPaymentHeader",
                table: "TrPaymentHeader",
                column: "PaymentHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcWarehouse",
                table: "DcWarehouse",
                column: "WarehouseCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcTerminal",
                table: "DcTerminal",
                column: "TerminalCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcStore",
                table: "DcStore",
                column: "StoreCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcProductType",
                table: "DcProductType",
                column: "ProductTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcProcess",
                table: "DcProcess",
                column: "ProcessCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcPaymentType",
                table: "DcPaymentType",
                column: "PaymentTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcOffice",
                table: "DcOffice",
                column: "OfficeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcCurrAccType",
                table: "DcCurrAccType",
                column: "CurrAccTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcCurrAcc",
                table: "DcCurrAcc",
                column: "CurrAccCode");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.DcCurrAcc_dbo.DcCurrAccType_CurrAccTypeCode",
                table: "DcCurrAcc",
                column: "CurrAccTypeCode",
                principalTable: "DcCurrAccType",
                principalColumn: "CurrAccTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.DcProduct_dbo.DcProductType_ProductTypeCode",
                table: "DcProduct",
                column: "ProductTypeCode",
                principalTable: "DcProductType",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCode",
                principalTable: "DcCurrAcc",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrShipmentLine_dbo.trShipmentHeader_ShipmentHeaderID",
                table: "TrShipmentLine",
                column: "ShipmentHeaderId",
                principalTable: "TrShipmentHeader",
                principalColumn: "ShipmentHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
