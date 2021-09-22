using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POSTerminalId",
                table: "TrInvoiceHeader",
                newName: "PosTerminalId");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrInvoiceHeader",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrInvoiceHeader",
                type: "date",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosTerminalId",
                table: "TrInvoiceHeader",
                newName: "POSTerminalId");

            migrationBuilder.AlterColumn<string>(
                name: "WarehouseCode",
                table: "TrInvoiceHeader",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrInvoiceHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrInvoiceHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "getdate()");
        }
    }
}
