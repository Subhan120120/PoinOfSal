using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrAccTypeDescription",
                table: "DcCurrAccTypes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrAccTypeDescription",
                table: "DcCurrAccTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
