using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class added_AppSetting_PrıntSettıngs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GetPrint",
                table: "AppSettings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PrinterCopyNum",
                table: "AppSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "AppSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GetPrint",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "PrinterCopyNum",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "AppSettings");
        }
    }
}
