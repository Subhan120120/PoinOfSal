using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines");

            migrationBuilder.AlterColumn<byte>(
                name: "PaymentTypeCode",
                table: "TrPaymentLines",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines");

            migrationBuilder.AlterColumn<byte>(
                name: "PaymentTypeCode",
                table: "TrPaymentLines",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrPaymentLines_DcPaymentTypes_PaymentTypeCode",
                table: "TrPaymentLines",
                column: "PaymentTypeCode",
                principalTable: "DcPaymentTypes",
                principalColumn: "PaymentTypeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
