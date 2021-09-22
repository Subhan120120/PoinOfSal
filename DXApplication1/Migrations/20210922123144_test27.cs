using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.RenameColumn(
                name: "ShippingPostalAddressID",
                table: "TrShipmentHeader",
                newName: "ShippingPostalAddressId");

            migrationBuilder.RenameColumn(
                name: "ShipmentHeaderID",
                table: "TrShipmentHeader",
                newName: "ShipmentHeaderId");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferApprovedDate",
                table: "TrShipmentHeader",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ToWarehouseCode",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeader",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeader",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingNumber",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "TrShipmentHeader",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessCode",
                table: "TrShipmentHeader",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeader",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrShipmentHeader",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrShipmentHeader",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrShipmentHeader",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrShipmentHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrShipmentHeader",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CustomsDocumentNumber",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrShipmentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrShipmentHeader",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrShipmentHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyCode",
                table: "TrShipmentHeader",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(4, 0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrInvoiceHeader",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrInvoiceHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCode",
                principalTable: "DcCurrAcc",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader");

            migrationBuilder.RenameColumn(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeader",
                newName: "ShippingPostalAddressID");

            migrationBuilder.RenameColumn(
                name: "ShipmentHeaderId",
                table: "TrShipmentHeader",
                newName: "ShipmentHeaderID");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrShipmentHeader",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransferApprovedDate",
                table: "TrShipmentHeader",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ToWarehouseCode",
                table: "TrShipmentHeader",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrShipmentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeader",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressID",
                table: "TrShipmentHeader",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ShippingNumber",
                table: "TrShipmentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShippingDate",
                table: "TrShipmentHeader",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessCode",
                table: "TrShipmentHeader",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeader",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OperationDate",
                table: "TrShipmentHeader",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrShipmentHeader",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrShipmentHeader",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrShipmentHeader",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrShipmentHeader",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomsDocumentNumber",
                table: "TrShipmentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrShipmentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrShipmentHeader",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrShipmentHeader",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyCode",
                table: "TrShipmentHeader",
                type: "numeric(4, 0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrInvoiceHeader",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrInvoiceHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrInvoiceHeader_dbo.DcCurrAcc_CurrAccCode",
                table: "TrInvoiceHeader",
                column: "CurrAccCode",
                principalTable: "DcCurrAcc",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
