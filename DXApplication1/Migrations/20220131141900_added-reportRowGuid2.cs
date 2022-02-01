using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedreportRowGuid2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DcReports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports",
                column: "RowGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DcReports",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports",
                column: "Id");
        }
    }
}
