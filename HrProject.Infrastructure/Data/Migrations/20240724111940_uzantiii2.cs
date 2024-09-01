using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uzantiii2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectElementTypes_ProjectElementTypeId",
                table: "FileProjeModul");

            migrationBuilder.RenameColumn(
                name: "ProjectElementTypeId",
                table: "FileProjeModul",
                newName: "ProjectElementId");

            migrationBuilder.RenameIndex(
                name: "IX_FileProjeModul_ProjectElementTypeId",
                table: "FileProjeModul",
                newName: "IX_FileProjeModul_ProjectElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul");

            migrationBuilder.RenameColumn(
                name: "ProjectElementId",
                table: "FileProjeModul",
                newName: "ProjectElementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FileProjeModul_ProjectElementId",
                table: "FileProjeModul",
                newName: "IX_FileProjeModul_ProjectElementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectElementTypes_ProjectElementTypeId",
                table: "FileProjeModul",
                column: "ProjectElementTypeId",
                principalTable: "ProjectElementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
