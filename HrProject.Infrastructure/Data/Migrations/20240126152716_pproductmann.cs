using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pproductmann : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderName",
                table: "ProductPlanProductPlanned",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductManifacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProductManifacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManifacts_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "ProductManifactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductManifactId = table.Column<int>(type: "int", nullable: false),
                    ProjectElementStepId = table.Column<int>(type: "int", nullable: false),
                    ProductStepEnum = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManifactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManifactDetails_ProductManifacts_ProductManifactId",
                        column: x => x.ProductManifactId,
                        principalTable: "ProductManifacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductManifactDetails_ProjectElementStep_ProjectElementStepId",
                        column: x => x.ProjectElementStepId,
                        principalTable: "ProjectElementStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductManifactDetailImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductManifactDetailId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManifactDetailImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductManifactDetailImages_ProductManifactDetails_ProductManifactDetailId",
                        column: x => x.ProductManifactDetailId,
                        principalTable: "ProductManifactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifactDetailImages_ProductManifactDetailId",
                table: "ProductManifactDetailImages",
                column: "ProductManifactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifactDetails_ProductManifactId",
                table: "ProductManifactDetails",
                column: "ProductManifactId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifactDetails_ProjectElementStepId",
                table: "ProductManifactDetails",
                column: "ProjectElementStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ConcreteProductionPlaceId",
                table: "ProductManifacts",
                column: "ConcreteProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_PmCalculateId",
                table: "ProductManifacts",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ProductionPlaceId",
                table: "ProductManifacts",
                column: "ProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_ProductPlanProductPlannedId",
                table: "ProductManifacts",
                column: "ProductPlanProductPlannedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductManifactDetailImages");

            migrationBuilder.DropTable(
                name: "ProductManifactDetails");

            migrationBuilder.DropTable(
                name: "ProductManifacts");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "ProductPlanProductPlanned");
        }
    }
}
