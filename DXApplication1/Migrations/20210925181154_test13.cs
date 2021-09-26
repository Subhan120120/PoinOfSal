using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "DcPaymentTypePaymentTypeCode", "PaymentTypeDescription" },
                values: new object[] { (byte)1, null, "Nağd" });

            migrationBuilder.InsertData(
                table: "DcPaymentTypes",
                columns: new[] { "PaymentTypeCode", "DcPaymentTypePaymentTypeCode", "PaymentTypeDescription" },
                values: new object[] { (byte)2, null, "Visa" });

            migrationBuilder.InsertData(
                table: "DcProductTypes",
                columns: new[] { "ProductTypeCode", "ProductTypeDesc" },
                values: new object[] { (byte)1, "Məhsul" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "DcProductTypes",
                keyColumn: "ProductTypeCode",
                keyValue: (byte)1);
        }
    }
}
