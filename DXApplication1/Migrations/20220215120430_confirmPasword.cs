using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class confirmPasword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "DcCurrAccs");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "DcCurrAccs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewPassword",
                table: "DcCurrAccs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "NewPassword",
                value: "123");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "NewPassword",
                value: "456");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "DcCurrAccs");

            migrationBuilder.DropColumn(
                name: "NewPassword",
                table: "DcCurrAccs");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "DcCurrAccs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1",
                column: "Password",
                value: "123");

            migrationBuilder.UpdateData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2",
                column: "Password",
                value: "456");
        }
    }
}
