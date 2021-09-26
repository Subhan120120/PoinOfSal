using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "ProductDescription",
                value: "Papaq");

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "ProductDescription",
                value: "Salvar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                column: "ProductDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                column: "ProductDescription",
                value: null);
        }
    }
}
