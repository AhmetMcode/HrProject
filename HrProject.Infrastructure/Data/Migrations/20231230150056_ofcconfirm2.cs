using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ofcconfirm2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferCalculateConfirm",
                table: "OfferParts");

            migrationBuilder.AddColumn<bool>(
                name: "OfferCalculateConfirm",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferCalculateConfirm",
                table: "Offers");

            migrationBuilder.AddColumn<bool>(
                name: "OfferCalculateConfirm",
                table: "OfferParts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
