using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "DcProducts",
                maxLength: 150,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "DcProducts",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "DcProducts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "DcProducts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldDefaultValueSql: "space(0)");
        }
    }
}
