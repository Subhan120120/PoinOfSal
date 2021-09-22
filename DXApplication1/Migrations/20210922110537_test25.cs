using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POSTerminalID",
                table: "TrPaymentHeader",
                newName: "PosterminalId");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrPaymentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<short>(
                name: "PosterminalId",
                table: "TrPaymentHeader",
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrPaymentHeader",
                maxLength: 5,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrPaymentHeader",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrPaymentHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "TrPaymentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "TrPaymentHeader",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrPaymentHeader",
                type: "time(0)",
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeader",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DocumentDate",
                table: "TrPaymentHeader",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeader",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "'00:00:00'",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentHeader",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrPaymentHeader",
                maxLength: 30,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrPaymentHeader",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrPaymentHeader",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyCode",
                table: "TrPaymentHeader",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(4, 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterminalId",
                table: "TrPaymentHeader",
                newName: "POSTerminalID");

            migrationBuilder.AlterColumn<string>(
                name: "StoreCode",
                table: "TrPaymentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<short>(
                name: "POSTerminalID",
                table: "TrPaymentHeader",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeCode",
                table: "TrPaymentHeader",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrPaymentHeader",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrPaymentHeader",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "TrPaymentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceHeaderId",
                table: "TrPaymentHeader",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DocumentTime",
                table: "TrPaymentHeader",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)",
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "TrPaymentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DocumentDate",
                table: "TrPaymentHeader",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(1901, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TrPaymentHeader",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "'00:00:00'");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentHeader",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrPaymentHeader",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrPaymentHeader",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrPaymentHeader",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<decimal>(
                name: "CompanyCode",
                table: "TrPaymentHeader",
                type: "numeric(4, 0)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
