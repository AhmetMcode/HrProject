using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaaa2222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifactDetails_ProductManifacts_ProductManifactId",
                table: "ProductManifactDetails");

            migrationBuilder.DropTable(
                name: "ProductManifacts");

            migrationBuilder.RenameColumn(
                name: "ProductManifactId",
                table: "ProductManifactDetails",
                newName: "ProductManifact2Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductManifactDetails_ProductManifactId",
                table: "ProductManifactDetails",
                newName: "IX_ProductManifactDetails_ProductManifact2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifactDetails_ProductManifacts2_ProductManifact2Id",
                table: "ProductManifactDetails",
                column: "ProductManifact2Id",
                principalTable: "ProductManifacts2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifactDetails_ProductManifacts2_ProductManifact2Id",
                table: "ProductManifactDetails");

            migrationBuilder.RenameColumn(
                name: "ProductManifact2Id",
                table: "ProductManifactDetails",
                newName: "ProductManifactId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductManifactDetails_ProductManifact2Id",
                table: "ProductManifactDetails",
                newName: "IX_ProductManifactDetails_ProductManifactId");

            migrationBuilder.CreateTable(
                name: "ProductManifacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcreteProductionPlaceId = table.Column<int>(type: "int", nullable: true),
                    ProductionPlaceId = table.Column<int>(type: "int", nullable: true),
                    ProductPlanProductPlannedId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManifacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManifacts_ProductPlanProductPlanned_ProductPlanProductPlannedId",
                        column: x => x.ProductPlanProductPlannedId,
                        principalTable: "ProductPlanProductPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductManifacts_ProductionPlaces_ConcreteProductionPlaceId",
                        column: x => x.ConcreteProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductManifacts_ProductionPlaces_ProductionPlaceId",
                        column: x => x.ProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ConcreteProductionPlaceId",
                table: "ProductManifacts",
                column: "ConcreteProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ProductionPlaceId",
                table: "ProductManifacts",
                column: "ProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ProductPlanProductPlannedId",
                table: "ProductManifacts",
                column: "ProductPlanProductPlannedId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifactDetails_ProductManifacts_ProductManifactId",
                table: "ProductManifactDetails",
                column: "ProductManifactId",
                principalTable: "ProductManifacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
