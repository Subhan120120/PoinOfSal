using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Migrations
{
    public partial class added_features : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    DcFeatureId = table.Column<int>(nullable: true),
                    DcProductProductCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrFeature_DcFeatures_DcFeatureId",
                        column: x => x.DcFeatureId,
                        principalTable: "DcFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrFeature_DcProducts_DcProductProductCode",
                        column: x => x.DcProductProductCode,
                        principalTable: "DcProducts",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrFeature_DcFeatureId",
                table: "TrFeature",
                column: "DcFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TrFeature_DcProductProductCode",
                table: "TrFeature",
                column: "DcProductProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrFeature");

            migrationBuilder.DropTable(
                name: "DcFeatures");
        }
    }
}
