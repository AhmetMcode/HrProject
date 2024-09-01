using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerPartCalculate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_Offers_OfferId",
                table: "OfferCalculates");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "OfferCalculates",
                newName: "OfferPartId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferCalculates_OfferId",
                table: "OfferCalculates",
                newName: "IX_OfferCalculates_OfferPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_OfferParts_OfferPartId",
                table: "OfferCalculates",
                column: "OfferPartId",
                principalTable: "OfferParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_OfferParts_OfferPartId",
                table: "OfferCalculates");

            migrationBuilder.RenameColumn(
                name: "OfferPartId",
                table: "OfferCalculates",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferCalculates_OfferPartId",
                table: "OfferCalculates",
                newName: "IX_OfferCalculates_OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_Offers_OfferId",
                table: "OfferCalculates",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
