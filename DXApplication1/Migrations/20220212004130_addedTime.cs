using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrPaymentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeaders",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrInvoiceHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrInvoiceHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "convert(varchar(10), GETDATE(), 108)",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ShippingTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrShipmentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrPaymentHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeaders",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrInvoiceHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrInvoiceHeaders",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "convert(varchar(10), GETDATE(), 108)");
        }
    }
}
