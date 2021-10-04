using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01");

            migrationBuilder.DeleteData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DcProducts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "DcProducts",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcProducts",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcProducts",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "DcProducts");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserName",
                table: "DcProducts");

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode", "RetailPrice" },
                values: new object[] { "test01", "123456", "Papaq", (byte)1, 4.5 });

            migrationBuilder.InsertData(
                table: "DcProducts",
                columns: new[] { "ProductCode", "Barcode", "ProductDescription", "ProductTypeCode", "RetailPrice" },
                values: new object[] { "test02", "2000000000013", "Salvar", (byte)1, 2.5 });
        }
    }
}
