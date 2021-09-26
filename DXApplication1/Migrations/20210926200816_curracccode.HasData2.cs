using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class curracccodeHasData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DcOffices",
                columns: new[] { "OfficeCode", "CompanyCode", "IsDisabled", "OfficeDesc", "RowGuid" },
                values: new object[,]
                {
                    { "OFS01", 0m, false, "Bakıxanov Ofisi", new Guid("00000000-0000-0000-0000-000000000000") },
                    { "OFS02", 0m, false, "Elmlər Ofisi", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "DcStores",
                columns: new[] { "StoreCode", "CompanyCode", "IsDisabled", "RowGuid", "StoreDesc" },
                values: new object[,]
                {
                    { "mgz-01", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Bakıxanov" },
                    { "mgz-02", 0m, false, new Guid("00000000-0000-0000-0000-000000000000"), "Elmlər" }
                });

            migrationBuilder.InsertData(
                table: "DcWarehouses",
                columns: new[] { "WarehouseCode", "ControlStockLevel", "IsDefault", "IsDisabled", "PermitNegativeStock", "RowGuid", "WarehouseDesc", "WarehouseTypeCode", "WarnNegativeStock", "WarnStockLevelRate" },
                values: new object[,]
                {
                    { "depo-01", false, false, false, false, new Guid("00000000-0000-0000-0000-000000000000"), "Bakıxanov deposu", (byte)0, false, false },
                    { "depo-02", false, false, false, false, new Guid("00000000-0000-0000-0000-000000000000"), "Elmlər deposu", (byte)0, false, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "OFS01");

            migrationBuilder.DeleteData(
                table: "DcOffices",
                keyColumn: "OfficeCode",
                keyValue: "OFS02");

            migrationBuilder.DeleteData(
                table: "DcStores",
                keyColumn: "StoreCode",
                keyValue: "mgz-01");

            migrationBuilder.DeleteData(
                table: "DcStores",
                keyColumn: "StoreCode",
                keyValue: "mgz-02");

            migrationBuilder.DeleteData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-01");

            migrationBuilder.DeleteData(
                table: "DcWarehouses",
                keyColumn: "WarehouseCode",
                keyValue: "depo-02");
        }
    }
}
