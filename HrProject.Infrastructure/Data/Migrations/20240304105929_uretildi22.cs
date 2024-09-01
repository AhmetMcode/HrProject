using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uretildi22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionPlaceId",
                table: "ConcreteRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteRequests_ProductionPlaceId",
                table: "ConcreteRequests",
                column: "ProductionPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteRequests_ProductionPlaces_ProductionPlaceId",
                table: "ConcreteRequests",
                column: "ProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteRequests_ProductionPlaces_ProductionPlaceId",
                table: "ConcreteRequests");

            migrationBuilder.DropIndex(
                name: "IX_ConcreteRequests_ProductionPlaceId",
                table: "ConcreteRequests");

            migrationBuilder.DropColumn(
                name: "ProductionPlaceId",
                table: "ConcreteRequests");
        }
    }
}
