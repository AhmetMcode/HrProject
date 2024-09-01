using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pedType3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_ProjectElementType_ProjectElementTypeId",
                table: "OfferCalculates");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementType_ProjectElements_ProjectElementId",
                table: "ProjectElementType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectElementType",
                table: "ProjectElementType");

            migrationBuilder.RenameTable(
                name: "ProjectElementType",
                newName: "ProjectElementTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementType_ProjectElementId",
                table: "ProjectElementTypes",
                newName: "IX_ProjectElementTypes_ProjectElementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectElementTypes",
                table: "ProjectElementTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_ProjectElementTypes_ProjectElementTypeId",
                table: "OfferCalculates",
                column: "ProjectElementTypeId",
                principalTable: "ProjectElementTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementTypes_ProjectElements_ProjectElementId",
                table: "ProjectElementTypes",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_ProjectElementTypes_ProjectElementTypeId",
                table: "OfferCalculates");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementTypes_ProjectElements_ProjectElementId",
                table: "ProjectElementTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectElementTypes",
                table: "ProjectElementTypes");

            migrationBuilder.RenameTable(
                name: "ProjectElementTypes",
                newName: "ProjectElementType");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementTypes_ProjectElementId",
                table: "ProjectElementType",
                newName: "IX_ProjectElementType_ProjectElementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectElementType",
                table: "ProjectElementType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_ProjectElementType_ProjectElementTypeId",
                table: "OfferCalculates",
                column: "ProjectElementTypeId",
                principalTable: "ProjectElementType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementType_ProjectElements_ProjectElementId",
                table: "ProjectElementType",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
