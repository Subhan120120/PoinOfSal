using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addedforeignKey_TrFeature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcFeatures_DcFeatureId",
                table: "TrFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcProducts_DcProductProductCode",
                table: "TrFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_DcFeatureId",
                table: "TrFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_DcProductProductCode",
                table: "TrFeatures");

            migrationBuilder.DropColumn(
                name: "DcFeatureId",
                table: "TrFeatures");

            migrationBuilder.DropColumn(
                name: "DcProductProductCode",
                table: "TrFeatures");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "TrFeatures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "TrFeatures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_FeatureId",
                table: "TrFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_ProductCode",
                table: "TrFeatures",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures",
                column: "FeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcProducts_ProductCode",
                table: "TrFeatures",
                column: "ProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcFeatures_FeatureId",
                table: "TrFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcProducts_ProductCode",
                table: "TrFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_FeatureId",
                table: "TrFeatures");

            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_ProductCode",
                table: "TrFeatures");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "TrFeatures");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "TrFeatures");

            migrationBuilder.AddColumn<int>(
                name: "DcFeatureId",
                table: "TrFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DcProductProductCode",
                table: "TrFeatures",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_DcFeatureId",
                table: "TrFeatures",
                column: "DcFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_DcProductProductCode",
                table: "TrFeatures",
                column: "DcProductProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcFeatures_DcFeatureId",
                table: "TrFeatures",
                column: "DcFeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeatures_DcProducts_DcProductProductCode",
                table: "TrFeatures",
                column: "DcProductProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
