using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class dada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "Id", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery" },
                values: new object[] { new Guid("d6186910-3619-428a-9eca-12f9672ff479"), null, null, "Satis", "select * from TrInvoiceLines" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "Id",
                keyValue: new Guid("d6186910-3619-428a-9eca-12f9672ff479"));
        }
    }
}
