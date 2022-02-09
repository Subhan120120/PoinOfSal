using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class addeduniqueKey_TrFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_FeatureId",
                table: "TrFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_FeatureId_ProductCode",
                table: "TrFeatures",
                columns: new[] { "FeatureId", "ProductCode" },
                unique: true,
                filter: "[ProductCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TrFeatures_FeatureId_ProductCode",
                table: "TrFeatures");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeatures_FeatureId",
                table: "TrFeatures",
                column: "FeatureId");
        }
    }
}
