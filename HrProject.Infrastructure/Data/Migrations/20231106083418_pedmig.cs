using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pedmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectElementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectElementId = table.Column<int>(type: "int", nullable: false),
                    PozNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    SteelMeshTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectElementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectElementDetails_ProjectElements_ProjectElementId",
                        column: x => x.ProjectElementId,
                        principalTable: "ProjectElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectElementDetails_SteelMeshType_SteelMeshTypeId",
                        column: x => x.SteelMeshTypeId,
                        principalTable: "SteelMeshType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectElementDetails_ProjectElementId",
                table: "ProjectElementDetails",
                column: "ProjectElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectElementDetails_SteelMeshTypeId",
                table: "ProjectElementDetails",
                column: "SteelMeshTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectElementDetails");
        }
    }
}
