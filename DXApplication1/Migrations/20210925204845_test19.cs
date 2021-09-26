using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UseInternet",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "TaxRate",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "RetailPrice",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PosDiscount",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBlocked",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UseInternet",
                table: "DcProducts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "TaxRate",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "RetailPrice",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<double>(
                name: "PosDiscount",
                table: "DcProducts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcProducts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsBlocked",
                table: "DcProducts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");
        }
    }
}
