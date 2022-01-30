using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedDcReport3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdatedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReportName = table.Column<string>(nullable: true),
                    ReportQuery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcReports");
        }
    }
}
