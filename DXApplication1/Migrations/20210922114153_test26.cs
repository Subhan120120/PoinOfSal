using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankID",
                table: "TrPaymentLine",
                newName: "BankId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLine",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrPaymentLine",
                maxLength: 200,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrPaymentLine",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrPaymentLine",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLine",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrPaymentLine",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrPaymentLine",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "TrPaymentLine",
                newName: "BankID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLine",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "LineDescription",
                table: "TrPaymentLine",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "TrPaymentLine",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "TrPaymentLine",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "TrPaymentLine",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "TrPaymentLine",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "TrPaymentLine",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");
        }
    }
}
