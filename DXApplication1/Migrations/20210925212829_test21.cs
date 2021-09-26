using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class test21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RelatedLineId",
                table: "TrInvoiceLines",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldDefaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RelatedLineId",
                table: "TrInvoiceLines",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "space(0)",
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
