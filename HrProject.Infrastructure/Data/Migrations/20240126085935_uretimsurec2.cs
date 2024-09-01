using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uretimsurec2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectElementStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectElementId = table.Column<int>(type: "int", nullable: false),
                    ProductionStepId = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    IsQuality = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectElementStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectElementStep_ProductionStep_ProductionStepId",
                        column: x => x.ProductionStepId,
                        principalTable: "ProductionStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectElementStep_ProjectElements_ProjectElementId",
                        column: x => x.ProjectElementId,
                        principalTable: "ProjectElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectElementStep_ProductionStepId",
                table: "ProjectElementStep",
                column: "ProductionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectElementStep_ProjectElementId",
                table: "ProjectElementStep",
                column: "ProjectElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectElementStep");
        }
    }
}
