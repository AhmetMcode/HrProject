using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class DetailOfferAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstOfferId",
                table: "DetailOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetailOffers_FirstOfferId",
                table: "DetailOffers",
                column: "FirstOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailOffers_FirstOffers_FirstOfferId",
                table: "DetailOffers",
                column: "FirstOfferId",
                principalTable: "FirstOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailOffers_FirstOffers_FirstOfferId",
                table: "DetailOffers");

            migrationBuilder.DropIndex(
                name: "IX_DetailOffers_FirstOfferId",
                table: "DetailOffers");

            migrationBuilder.DropColumn(
                name: "FirstOfferId",
                table: "DetailOffers");
        }
    }
}
