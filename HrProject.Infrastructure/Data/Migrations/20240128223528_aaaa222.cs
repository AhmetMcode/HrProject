using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaaa222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductManifacts2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPlanProductPlannedId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ProductionPlaceId = table.Column<int>(type: "int", nullable: true),
                    ConcreteProductionPlaceId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManifacts2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManifacts2_ProductPlanProductPlanned_ProductPlanProductPlannedId",
                        column: x => x.ProductPlanProductPlannedId,
                        principalTable: "ProductPlanProductPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductManifacts2_ProductionPlaces_ConcreteProductionPlaceId",
                        column: x => x.ConcreteProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductManifacts2_ProductionPlaces_ProductionPlaceId",
                        column: x => x.ProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts2_ConcreteProductionPlaceId",
                table: "ProductManifacts2",
                column: "ConcreteProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts2_ProductionPlaceId",
                table: "ProductManifacts2",
                column: "ProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts2_ProductPlanProductPlannedId",
                table: "ProductManifacts2",
                column: "ProductPlanProductPlannedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductManifacts2");
        }
    }
}
