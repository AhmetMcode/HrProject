using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaaa2222w2225 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts2_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts2");

            migrationBuilder.RenameColumn(
                name: "ProductionPlaceId",
                table: "ProductManifacts2",
                newName: "IronProductionPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductManifacts2_ProductionPlaceId",
                table: "ProductManifacts2",
                newName: "IX_ProductManifacts2_IronProductionPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts2_ProductionPlaces_IronProductionPlaceId",
                table: "ProductManifacts2",
                column: "IronProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts2_ProductionPlaces_IronProductionPlaceId",
                table: "ProductManifacts2");

            migrationBuilder.RenameColumn(
                name: "IronProductionPlaceId",
                table: "ProductManifacts2",
                newName: "ProductionPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductManifacts2_IronProductionPlaceId",
                table: "ProductManifacts2",
                newName: "IX_ProductManifacts2_ProductionPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts2_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts2",
                column: "ProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id");
        }
    }
}
