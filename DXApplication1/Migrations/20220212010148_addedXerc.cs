using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedXerc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcProductTypes",
                columns: new[] { "ProductTypeCode", "ProductTypeDesc" },
                values: new object[] { (byte)2, "Xərc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProductTypes",
                keyColumn: "ProductTypeCode",
                keyValue: (byte)2);
        }
    }
}
