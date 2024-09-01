using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class similar4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementDetails_ProjectElements_ProjectElementId",
                table: "ProjectElementDetails");

            migrationBuilder.RenameColumn(
                name: "ProjectElementId",
                table: "ProjectElementDetails",
                newName: "OfferCalculateId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementDetails_ProjectElementId",
                table: "ProjectElementDetails",
                newName: "IX_ProjectElementDetails_OfferCalculateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementDetails_OfferCalculates_OfferCalculateId",
                table: "ProjectElementDetails",
                column: "OfferCalculateId",
                principalTable: "OfferCalculates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementDetails_OfferCalculates_OfferCalculateId",
                table: "ProjectElementDetails");

            migrationBuilder.RenameColumn(
                name: "OfferCalculateId",
                table: "ProjectElementDetails",
                newName: "ProjectElementId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementDetails_OfferCalculateId",
                table: "ProjectElementDetails",
                newName: "IX_ProjectElementDetails_ProjectElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementDetails_ProjectElements_ProjectElementId",
                table: "ProjectElementDetails",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
