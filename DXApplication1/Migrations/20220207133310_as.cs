using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "Id",
                keyValue: new Guid("d6186910-3619-428a-9eca-12f9672ff479"));

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "Id", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery" },
                values: new object[] { new Guid("01fdab8b-0c03-4bdb-bc07-c03ff743ce45"), null, null, "Satis", "select * from TrInvoiceLines" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcReports",
                keyColumn: "Id",
                keyValue: new Guid("01fdab8b-0c03-4bdb-bc07-c03ff743ce45"));

            migrationBuilder.InsertData(
                table: "DcReports",
                columns: new[] { "Id", "ReportFilter", "ReportLayout", "ReportName", "ReportQuery" },
                values: new object[] { new Guid("d6186910-3619-428a-9eca-12f9672ff479"), null, null, "Satis", "select * from TrInvoiceLines" });
        }
    }
}
