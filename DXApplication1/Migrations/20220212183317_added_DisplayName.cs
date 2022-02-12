using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class added_DisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemTypeCode",
                table: "TrShipmentLines");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "DcProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeaders",
                maxLength: 60,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomsDocumentNumber",
                table: "TrShipmentHeaders",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrInvoiceLines",
                maxLength: 100,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "DcWarehouses",
                maxLength: 5,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeDesc",
                table: "DcProductTypes",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessDescription",
                table: "DcProcesses",
                maxLength: 150,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTypeDesc",
                table: "DcPaymentTypes",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNum",
                table: "DcCurrAccs",
                maxLength: 150,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ItemTypeCode",
                table: "TrShipmentLines",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShippingPostalAddressId",
                table: "TrShipmentHeaders",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldMaxLength: 60,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomsDocumentNumber",
                table: "TrShipmentHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "DcWarehouses",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeDesc",
                table: "DcProductTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "DcProducts",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessDescription",
                table: "DcProcesses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTypeDesc",
                table: "DcPaymentTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNum",
                table: "DcCurrAccs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }
    }
}
