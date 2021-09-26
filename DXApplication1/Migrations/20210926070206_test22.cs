using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcPaymentTypes_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes");

            migrationBuilder.DropColumn(
                name: "DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes");

            migrationBuilder.DropColumn(
                name: "PaymentTypeDescription",
                table: "DcPaymentTypes");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTypeDesc",
                table: "DcPaymentTypes",
                maxLength: 100,
                nullable: true,
                defaultValueSql: "space(0)");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)1,
                column: "PaymentTypeDesc",
                value: "Nağd");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)2,
                column: "PaymentTypeDesc",
                value: "Visa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTypeDesc",
                table: "DcPaymentTypes");

            migrationBuilder.AddColumn<byte>(
                name: "DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTypeDescription",
                table: "DcPaymentTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                defaultValueSql: "space(0)");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)1,
                column: "PaymentTypeDescription",
                value: "Nağd");

            migrationBuilder.UpdateData(
                table: "DcPaymentTypes",
                keyColumn: "PaymentTypeCode",
                keyValue: (byte)2,
                column: "PaymentTypeDescription",
                value: "Visa");

            migrationBuilder.CreateIndex(
                name: "IX_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes",
                column: "DcPaymentTypePaymentTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_DcPaymentTypes_DcPaymentTypes_DcPaymentTypePaymentTypeCode",
                table: "DcPaymentTypes",
                column: "DcPaymentTypePaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
