using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class asasa111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferTerminDetail_ProjectElements_ProjectElementId",
                table: "OfferTerminDetail");

            migrationBuilder.RenameColumn(
                name: "ProjectElementId",
                table: "OfferTerminDetail",
                newName: "ProjectElementTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferTerminDetail_ProjectElementId",
                table: "OfferTerminDetail",
                newName: "IX_OfferTerminDetail_ProjectElementTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferTerminDetail_ProjectElementTypes_ProjectElementTypeId",
                table: "OfferTerminDetail",
                column: "ProjectElementTypeId",
                principalTable: "ProjectElementTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferTerminDetail_ProjectElementTypes_ProjectElementTypeId",
                table: "OfferTerminDetail");

            migrationBuilder.RenameColumn(
                name: "ProjectElementTypeId",
                table: "OfferTerminDetail",
                newName: "ProjectElementId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferTerminDetail_ProjectElementTypeId",
                table: "OfferTerminDetail",
                newName: "IX_OfferTerminDetail_ProjectElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferTerminDetail_ProjectElements_ProjectElementId",
                table: "OfferTerminDetail",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
