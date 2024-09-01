using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class donatiraporr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjeDonatiRaporu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    IronDiameterWeightId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeDonatiRaporu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeDonatiRaporu_IronDiameterWeights_IronDiameterWeightId",
                        column: x => x.IronDiameterWeightId,
                        principalTable: "IronDiameterWeights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeDonatiRaporu_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDonatiRaporu_IronDiameterWeightId",
                table: "ProjeDonatiRaporu",
                column: "IronDiameterWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeDonatiRaporu_ProjectModuleSubId",
                table: "ProjeDonatiRaporu",
                column: "ProjectModuleSubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjeDonatiRaporu");
        }
    }
}
