using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerpartdemirbetonhalatgasir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Beton",
                table: "OfferParts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Demir",
                table: "OfferParts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Halat",
                table: "OfferParts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Hasir",
                table: "OfferParts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beton",
                table: "OfferParts");

            migrationBuilder.DropColumn(
                name: "Demir",
                table: "OfferParts");

            migrationBuilder.DropColumn(
                name: "Halat",
                table: "OfferParts");

            migrationBuilder.DropColumn(
                name: "Hasir",
                table: "OfferParts");
        }
    }
}
