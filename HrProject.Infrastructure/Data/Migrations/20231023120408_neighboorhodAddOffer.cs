using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class neighboorhodAddOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighbourhoodId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_NeighbourhoodId",
                table: "Offers",
                column: "NeighbourhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Neighbourhoods_NeighbourhoodId",
                table: "Offers",
                column: "NeighbourhoodId",
                principalTable: "Neighbourhoods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Neighbourhoods_NeighbourhoodId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_NeighbourhoodId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "NeighbourhoodId",
                table: "Offers");
        }
    }
}
