using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedreportRowGuid4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports");

            migrationBuilder.DropColumn(
                name: "RowGuid",
                table: "DcReports");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DcReports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DcReports");

            migrationBuilder.AddColumn<Guid>(
                name: "RowGuid",
                table: "DcReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcReports",
                table: "DcReports",
                column: "RowGuid");
        }
    }
}
