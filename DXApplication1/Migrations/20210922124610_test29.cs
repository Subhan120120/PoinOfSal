using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipmentHeaderID",
                table: "TrShipmentLine",
                newName: "ShipmentHeaderId");

            migrationBuilder.RenameColumn(
                name: "ShipmentLineID",
                table: "TrShipmentLine",
                newName: "ShipmentLineId");

            migrationBuilder.AlterColumn<string>(
                name: "UsedBarcode",
                table: "TrShipmentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SalespersonCode",
                table: "TrShipmentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDimensionCode",
                table: "TrShipmentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrShipmentLine",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrShipmentLine",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrShipmentLine",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrShipmentLine",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrShipmentLine",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrShipmentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrShipmentLine",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrShipmentLine",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "ColorCode",
                table: "TrShipmentLine",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLine",
                maxLength: 30,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipmentHeaderId",
                table: "TrShipmentLine",
                newName: "ShipmentHeaderID");

            migrationBuilder.RenameColumn(
                name: "ShipmentLineId",
                table: "TrShipmentLine",
                newName: "ShipmentLineID");

            migrationBuilder.AlterColumn<string>(
                name: "UsedBarcode",
                table: "TrShipmentLine",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "SalespersonCode",
                table: "TrShipmentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDimensionCode",
                table: "TrShipmentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrShipmentLine",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "TrShipmentLine",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrShipmentLine",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrShipmentLine",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrShipmentLine",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrShipmentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrShipmentLine",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrShipmentLine",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "ColorCode",
                table: "TrShipmentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLine",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }
    }
}
