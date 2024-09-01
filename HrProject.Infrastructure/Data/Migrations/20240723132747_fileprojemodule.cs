using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class fileprojemodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileProjeModul",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    ProjectElementTypeId = table.Column<int>(type: "int", nullable: false),
                    Dosya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevizeNo = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileProjeModul", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileProjeModul_ProjectElementTypes_ProjectElementTypeId",
                        column: x => x.ProjectElementTypeId,
                        principalTable: "ProjectElementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileProjeModul_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileProjeModul_ProjectElementTypeId",
                table: "FileProjeModul",
                column: "ProjectElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FileProjeModul_ProjectModuleSubId",
                table: "FileProjeModul",
                column: "ProjectModuleSubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileProjeModul");
        }
    }
}
