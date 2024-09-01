using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferCostCategoryId = table.Column<int>(type: "int", nullable: false),
                    CurrentValueId = table.Column<int>(type: "int", nullable: false),
                    Formula = table.Column<bool>(type: "bit", nullable: false),
                    Formulas = table.Column<int>(type: "int", nullable: true),
                    Wastage = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferMaterials_CurrentValues_CurrentValueId",
                        column: x => x.CurrentValueId,
                        principalTable: "CurrentValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferMaterials_OfferCostCategorys_OfferCostCategoryId",
                        column: x => x.OfferCostCategoryId,
                        principalTable: "OfferCostCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferMaterials_CurrentValueId",
                table: "OfferMaterials",
                column: "CurrentValueId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferMaterials_OfferCostCategoryId",
                table: "OfferMaterials",
                column: "OfferCostCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferMaterials");
        }
    }
}
