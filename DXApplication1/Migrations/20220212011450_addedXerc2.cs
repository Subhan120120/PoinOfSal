using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedXerc2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode" },
                values: new object[] { "xerc01", "", "Yol Xerci", (byte)2 });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode" },
                values: new object[] { "xerc02", "", "Isiq Pulu", (byte)2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "xerc02");
        }
    }
}
