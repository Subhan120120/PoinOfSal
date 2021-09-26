using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class curracccodeHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLines",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDescription", "IsDisabled", "RowGuid" },
                values: new object[] { (byte)1, "Müştəri", false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDescription", "IsDisabled", "RowGuid" },
                values: new object[] { (byte)2, "Tədarikçi", false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcCurrAccTypes",
                columns: new[] { "CurrAccTypeCode", "CurrAccTypeDescription", "IsDisabled", "RowGuid" },
                values: new object[] { (byte)3, "Personal", false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "CurrAccTypeCode", "CustomerPosDiscountRate", "CustomerTypeCode", "FirstName", "IsDisabled", "LastName", "PhoneNum", "RowGuid", "VendorTypeCode" },
                values: new object[] { "CA-1", (byte)0, (byte)1, 0.0, (byte)0, "Sübhan", false, "Hüseynzadə", "0519678909", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 });

            migrationBuilder.InsertData(
                table: "DcCurrAccs",
                columns: new[] { "CurrAccCode", "CompanyCode", "CurrAccTypeCode", "CustomerPosDiscountRate", "CustomerTypeCode", "FirstName", "IsDisabled", "LastName", "PhoneNum", "RowGuid", "VendorTypeCode" },
                values: new object[] { "CA-2", (byte)0, (byte)2, 0.0, (byte)0, "Orxan", false, "Hüseynzadə", "0773628800", new Guid("00000000-0000-0000-0000-000000000000"), (byte)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-1");

            migrationBuilder.DeleteData(
                table: "DcCurrAccs",
                keyColumn: "CurrAccCode",
                keyValue: "CA-2");

            migrationBuilder.DeleteData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "DcCurrAccTypes",
                keyColumn: "CurrAccTypeCode",
                keyValue: (byte)2);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "TrInvoiceLines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
