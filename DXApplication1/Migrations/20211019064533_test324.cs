using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test324 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StringReturn");

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "LastNumber", "ProcessDescription" },
                values: new object[,]
                {
                    { "RS", null, "Pərakəndə Satış" },
                    { "RP", null, "Pərakəndə Alış" },
                    { "P", null, "Ödəmə" },
                    { "CA", null, "Cari" },
                    { "SB", null, "Toptan Alış" },
                    { "W", null, "Toptan Satış" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "P");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RP");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "RS");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "SB");

            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "W");

            migrationBuilder.CreateTable(
                name: "StringReturn",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
