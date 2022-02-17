using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedvatiable5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProcesses",
                keyColumn: "ProcessCode",
                keyValue: "CA");

            migrationBuilder.DropColumn(
                name: "DcVariableDescription",
                table: "DcVariables");

            migrationBuilder.AddColumn<string>(
                name: "DcVariableDesc",
                table: "DcVariables",
                maxLength: 150,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "DcVariableCode", "DcVariableDesc", "LastNumber" },
                values: new object[] { "CA", "Cari", null });

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "DcVariableCode", "DcVariableDesc", "LastNumber" },
                values: new object[] { "PR", "Məhsul", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "PR");

            migrationBuilder.DropColumn(
                name: "DcVariableDesc",
                table: "DcVariables");

            migrationBuilder.AddColumn<string>(
                name: "DcVariableDescription",
                table: "DcVariables",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.InsertData(
                table: "DcProcesses",
                columns: new[] { "ProcessCode", "LastNumber", "ProcessDescription" },
                values: new object[] { "CA", null, "Cari" });
        }
    }
}
