using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UsePos",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "UsePos",
                table: "DcProducts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");
        }
    }
}
