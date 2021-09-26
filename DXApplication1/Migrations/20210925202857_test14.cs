using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "RetailPrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { "test01", "123456", null, null, null, null, null, 4.5, null, null, null, null });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "RetailPrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { "test02", "2000000000013", null, null, null, null, null, 2.5, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02");
        }
    }
}
