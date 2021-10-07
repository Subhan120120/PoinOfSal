using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test1212 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalespersonCode",
                table: "TrInvoiceLines",
                newName: "SalesPersonCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesPersonCode",
                table: "TrInvoiceLines",
                newName: "SalespersonCode");
        }
    }
}
