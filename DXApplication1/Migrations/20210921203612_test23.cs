using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TrInvoiceLine_dbo.DcProduct_ProductCode",
                table: "TrInvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.DcProduct",
                table: "DcProduct");

            migrationBuilder.AddColumn<string>(
                name: "ProductCodeNavigationProductCode",
                table: "TrInvoiceLine",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcTerminal",
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcTerminal",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcTerminal",
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcTerminal",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "StoreDesc",
                table: "DcStore",
                maxLength: 150,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcStore",
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcStore",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcStore",
                nullable: true,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcStore",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeDesc",
                table: "DcProductType",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromotionCode2",
                table: "DcProduct",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromotionCode",
                table: "DcProduct",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "DcProduct",
                maxLength: 150,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "DcProduct",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "DcProduct",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ProcessDescription",
                table: "DcProcess",
                maxLength: 200,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTypeDescription",
                table: "DcPaymentType",
                maxLength: 100,
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OfficeDesc",
                table: "DcOffice",
                maxLength: 150,
                nullable: false,
                defaultValueSql: "space(0)",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcOffice",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcOffice",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcOffice",
                maxLength: 20,
                nullable: false,
                defaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcOffice",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DcProduct",
                table: "DcProduct",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrInvoiceLine_ProductCodeNavigationProductCode",
                table: "TrInvoiceLine",
                column: "ProductCodeNavigationProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrInvoiceLine_DcProduct_ProductCodeNavigationProductCode",
                table: "TrInvoiceLine",
                column: "ProductCodeNavigationProductCode",
                principalTable: "DcProduct",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrInvoiceLine_DcProduct_ProductCodeNavigationProductCode",
                table: "TrInvoiceLine");

            migrationBuilder.DropIndex(
                name: "IX_TrInvoiceLine_ProductCodeNavigationProductCode",
                table: "TrInvoiceLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DcProduct",
                table: "DcProduct");

            migrationBuilder.DropColumn(
                name: "ProductCodeNavigationProductCode",
                table: "TrInvoiceLine");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcTerminal",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcTerminal",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcTerminal",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcTerminal",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "StoreDesc",
                table: "DcStore",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcStore",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcStore",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcStore",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcStore",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypeDesc",
                table: "DcProductType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PromotionCode2",
                table: "DcProduct",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PromotionCode",
                table: "DcProduct",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "DcProduct",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "DcProduct",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "DcProduct",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ProcessDescription",
                table: "DcProcess",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTypeDescription",
                table: "DcPaymentType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeDesc",
                table: "DcOffice",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldDefaultValueSql: "space(0)");

            migrationBuilder.AlterColumn<string>(
                name: "LastUpdatedUserName",
                table: "DcOffice",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "DcOffice",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserName",
                table: "DcOffice",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldDefaultValueSql: "substring(suser_name(),patindex('%\\%',suser_name())+(1),(20))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DcOffice",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.DcProduct",
                table: "DcProduct",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.TrInvoiceLine_dbo.DcProduct_ProductCode",
                table: "TrInvoiceLine",
                column: "ProductCode",
                principalTable: "DcProduct",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
