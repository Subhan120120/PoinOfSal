using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrInvoiceHeader",
                type: "time(0)",
                nullable: true,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrInvoiceHeader",
                type: "time(0)",
                nullable: true,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OperationTime",
                table: "TrInvoiceHeader",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldNullable: true,
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrInvoiceHeader",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldNullable: true,
                oldDefaultValueSql: "'00:00:00'");
        }
    }
}
