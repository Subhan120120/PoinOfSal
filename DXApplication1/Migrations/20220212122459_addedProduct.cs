using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLines",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLines_DcProducts_ProductCode",
                table: "TrInvoiceLines",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
