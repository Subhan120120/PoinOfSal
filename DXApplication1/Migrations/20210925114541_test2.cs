using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true,
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PosDiscount",
                table: "TrInvoiceLines",
                type: "money",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValueSql: "0");
        }
    }
}
