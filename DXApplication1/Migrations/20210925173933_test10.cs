using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<byte>(
                name: "BankId",
                table: "TrPaymentLines",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "TrInvoiceLines",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccTypeDescription",
                table: "DcCurrAccTypes",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Payment",
                table: "TrPaymentLines",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "ExchangeRate",
                table: "TrPaymentLines",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<byte>(
                name: "BankId",
                table: "TrPaymentLines",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "TrInvoiceLines",
                type: "int",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "TrInvoiceLines",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccTypeDescription",
                table: "DcCurrAccTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldDefaultValueSql: "space(0)");
        }
    }
}
