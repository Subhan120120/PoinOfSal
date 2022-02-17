using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedvatiable6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastNumber",
                table: "DcProcesses");

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "DcVariableCode", "DcVariableDesc", "LastNumber" },
                values: new object[,]
                {
                    { "RS", "Pərakəndə Satış", null },
                    { "RP", "Pərakəndə Alış", null },
                    { "P", "Ödəmə", null },
                    { "SB", "Toptan Alış", null },
                    { "W", "Toptan Satış", null },
                    { "EX", "Xərclər", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "EX");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "P");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "RP");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "RS");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "SB");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "W");

            migrationBuilder.AddColumn<int>(
                name: "LastNumber",
                table: "DcProcesses",
                type: "int",
                nullable: true);
        }
    }
}
