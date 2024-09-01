using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ofcCalc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferCostCalculateDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferPartId = table.Column<int>(type: "int", nullable: false),
                    OfferMaterialsId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCostCalculateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCostCalculateDetails_OfferMaterials_OfferMaterialsId",
                        column: x => x.OfferMaterialsId,
                        principalTable: "OfferMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferCostCalculateDetails_OfferParts_OfferPartId",
                        column: x => x.OfferPartId,
                        principalTable: "OfferParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferCostCalculateDetails_OfferMaterialsId",
                table: "OfferCostCalculateDetails",
                column: "OfferMaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCostCalculateDetails_OfferPartId",
                table: "OfferCostCalculateDetails",
                column: "OfferPartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferCostCalculateDetails");
        }
    }
}
