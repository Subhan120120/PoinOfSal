using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedvatiable7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcVariables",
                table: "DcVariables");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "DcVariableCode",
                keyValue: "CA");

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
                keyValue: "PR");

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

            migrationBuilder.DropColumn(
                name: "DcVariableCode",
                table: "DcVariables");

            migrationBuilder.DropColumn(
                name: "DcVariableDesc",
                table: "DcVariables");

            migrationBuilder.AddColumn<string>(
                name: "VariableCode",
                table: "DcVariables",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VariableDesc",
                table: "DcVariables",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcVariables",
                table: "DcVariables",
                column: "VariableCode");

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "VariableCode", "LastNumber", "VariableDesc" },
                values: new object[,]
                {
                    { "CA", null, "Cari" },
                    { "PR", null, "Məhsul" },
                    { "RS", null, "Pərakəndə Satış" },
                    { "RP", null, "Pərakəndə Alış" },
                    { "P", null, "Ödəmə" },
                    { "SB", null, "Toptan Alış" },
                    { "W", null, "Toptan Satış" },
                    { "EX", null, "Xərclər" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DcVariables",
                table: "DcVariables");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "EX");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "P");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "PR");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RP");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "RS");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "SB");

            migrationBuilder.DeleteData(
                table: "DcVariables",
                keyColumn: "VariableCode",
                keyValue: "W");

            migrationBuilder.DropColumn(
                name: "VariableCode",
                table: "DcVariables");

            migrationBuilder.DropColumn(
                name: "VariableDesc",
                table: "DcVariables");

            migrationBuilder.AddColumn<string>(
                name: "DcVariableCode",
                table: "DcVariables",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DcVariableDesc",
                table: "DcVariables",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcVariables",
                table: "DcVariables",
                column: "DcVariableCode");

            migrationBuilder.InsertData(
                table: "DcVariables",
                columns: new[] { "DcVariableCode", "DcVariableDesc", "LastNumber" },
                values: new object[,]
                {
                    { "CA", "Cari", null },
                    { "PR", "Məhsul", null },
                    { "RS", "Pərakəndə Satış", null },
                    { "RP", "Pərakəndə Alış", null },
                    { "P", "Ödəmə", null },
                    { "SB", "Toptan Alış", null },
                    { "W", "Toptan Satış", null },
                    { "EX", "Xərclər", null }
                });
        }
    }
}
