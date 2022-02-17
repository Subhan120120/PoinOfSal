using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedvatiable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcVariables",
                columns: table => new
                {
                    DcVariableCode = table.Column<string>(maxLength: 5, nullable: false),
                    DcVariableDescription = table.Column<string>(maxLength: 150, nullable: true),
                    LastNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcVariables", x => x.DcVariableCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcVariables");
        }
    }
}
