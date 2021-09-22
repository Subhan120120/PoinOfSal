using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrInvoiceLine_dbo.TrInvoiceHeader_InvoiceHeaderId",
                table: "TrInvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.TrInvoiceLine",
                table: "TrInvoiceLine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrInvoiceLine",
                table: "TrInvoiceLine",
                column: "InvoiceLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLine_TrInvoiceHeader_InvoiceHeaderId",
                table: "TrInvoiceLine",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeader",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLine_TrInvoiceHeader_InvoiceHeaderId",
                table: "TrInvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrInvoiceLine",
                table: "TrInvoiceLine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.TrInvoiceLine",
                table: "TrInvoiceLine",
                column: "InvoiceLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrInvoiceLine_dbo.TrInvoiceHeader_InvoiceHeaderId",
                table: "TrInvoiceLine",
                column: "InvoiceHeaderId",
                principalTable: "TrInvoiceHeader",
                principalColumn: "InvoiceHeaderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
