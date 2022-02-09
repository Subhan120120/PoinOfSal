using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class added_features2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFeature_DcFeatures_DcFeatureId",
                table: "TrFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeature_DcProducts_DcProductProductCode",
                table: "TrFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrFeature",
                table: "TrFeature");

            migrationBuilder.RenameTable(
                name: "TrFeature",
                newName: "TrFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_TrFeature_DcProductProductCode",
                table: "TrFeatures",
                newName: "IX_TrFeatures_DcProductProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrFeature_DcFeatureId",
                table: "TrFeatures",
                newName: "IX_TrFeatures_DcFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrFeatures",
                table: "TrFeatures",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcFeatures_DcFeatureId",
                table: "TrFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_TrFeatures_DcProducts_DcProductProductCode",
                table: "TrFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrFeatures",
                table: "TrFeatures");

            migrationBuilder.RenameTable(
                name: "TrFeatures",
                newName: "TrFeature");

            migrationBuilder.RenameIndex(
                name: "IX_TrFeatures_DcProductProductCode",
                table: "TrFeature",
                newName: "IX_TrFeature_DcProductProductCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrFeatures_DcFeatureId",
                table: "TrFeature",
                newName: "IX_TrFeature_DcFeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrFeature",
                table: "TrFeature",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeature_DcFeatures_DcFeatureId",
                table: "TrFeature",
                column: "DcFeatureId",
                principalTable: "DcFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrFeature_DcProducts_DcProductProductCode",
                table: "TrFeature",
                column: "DcProductProductCode",
                principalTable: "DcProducts",
                principalColumn: "ProductCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
