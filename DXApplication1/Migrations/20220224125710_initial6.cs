using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrInvoiceHeaders",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                table: "TrInvoiceHeaders",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                table: "TrInvoiceHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "CurrAccCode",
                table: "TrInvoiceHeaders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceHeaders_DcCurrAccs_CurrAccCode",
                table: "TrInvoiceHeaders",
                column: "CurrAccCode",
                principalTable: "DcCurrAccs",
                principalColumn: "CurrAccCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
