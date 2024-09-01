using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class projectelementid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectElementId",
                table: "OfferCalculates",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_OfferCalculates_ProjectElementId",
                table: "OfferCalculates",
                column: "ProjectElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_ProjectElements_ProjectElementId",
                table: "OfferCalculates",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_ProjectElements_ProjectElementId",
                table: "OfferCalculates");

            migrationBuilder.DropIndex(
                name: "IX_OfferCalculates_ProjectElementId",
                table: "OfferCalculates");

            migrationBuilder.DropColumn(
                name: "ProjectElementId",
                table: "OfferCalculates");
        }
    }
}
