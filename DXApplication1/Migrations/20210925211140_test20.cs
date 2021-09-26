using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RelatedLineId",
                table: "TrInvoiceLines",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrInvoiceLines",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "VatRate",
                table: "TrInvoiceLines",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<Guid>(
                name: "RelatedLineId",
                table: "TrInvoiceLines",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetAmount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrInvoiceLines",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrInvoiceLines",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountCampaign",
                table: "TrInvoiceLines",
                type: "money",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");
        }
    }
}
