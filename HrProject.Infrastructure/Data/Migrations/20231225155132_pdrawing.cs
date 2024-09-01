using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pdrawing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionDrawings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    ProjectProcessStage = table.Column<int>(type: "int", nullable: false),
                    SubStage = table.Column<int>(type: "int", nullable: false),
                    RecipentUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ResponsibleUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDrawings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionDrawings_AspNetUsers_RecipentUserId",
                        column: x => x.RecipentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductionDrawings_AspNetUsers_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductionDrawings_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDrawings_ProjectModuleSubId",
                table: "ProductionDrawings",
                column: "ProjectModuleSubId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDrawings_RecipentUserId",
                table: "ProductionDrawings",
                column: "RecipentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDrawings_ResponsibleUserId",
                table: "ProductionDrawings",
                column: "ResponsibleUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionDrawings");
        }
    }
}
