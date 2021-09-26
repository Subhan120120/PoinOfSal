using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts");

            migrationBuilder.AlterColumn<double>(
                name: "WholesalePrice",
                table: "DcProducts",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UsePos",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "UseInternet",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TaxRate",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RetailPrice",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ProductTypeCode",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PosDiscount",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsBlocked",
                table: "DcProducts",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                columns: new[] { "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { false, false, 0.0, (byte)0, 0.0, 0.0, false, false, 0.0 });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                columns: new[] { "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { false, false, 0.0, (byte)0, 0.0, 0.0, false, false, 0.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode",
                principalTable: "DcProductTypes",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts");

            migrationBuilder.AlterColumn<double>(
                name: "WholesalePrice",
                table: "DcProducts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "UsePos",
                table: "DcProducts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "UseInternet",
                table: "DcProducts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<double>(
                name: "TaxRate",
                table: "DcProducts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "RetailPrice",
                table: "DcProducts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "PurchasePrice",
                table: "DcProducts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<byte>(
                name: "ProductTypeCode",
                table: "DcProducts",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<double>(
                name: "PosDiscount",
                table: "DcProducts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabled",
                table: "DcProducts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "IsBlocked",
                table: "DcProducts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test01",
                columns: new[] { "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "DcProducts",
                keyColumn: "ProductCode",
                keyValue: "test02",
                columns: new[] { "IsBlocked", "IsDisabled", "PosDiscount", "ProductTypeCode", "PurchasePrice", "TaxRate", "UseInternet", "UsePos", "WholesalePrice" },
                values: new object[] { null, null, null, null, null, null, null, null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_DcProducts_DcProductTypes_ProductTypeCode",
                table: "DcProducts",
                column: "ProductTypeCode",
                principalTable: "DcProductTypes",
                principalColumn: "ProductTypeCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
