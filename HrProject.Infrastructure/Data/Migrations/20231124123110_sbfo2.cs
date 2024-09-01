using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class sbfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubFirstOfferId",
                table: "FirstOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FirstOffers_SubFirstOfferId",
                table: "FirstOffers",
                column: "SubFirstOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstOffers_SubFirstOffers_SubFirstOfferId",
                table: "FirstOffers",
                column: "SubFirstOfferId",
                principalTable: "SubFirstOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstOffers_SubFirstOffers_SubFirstOfferId",
                table: "FirstOffers");

            migrationBuilder.DropIndex(
                name: "IX_FirstOffers_SubFirstOfferId",
                table: "FirstOffers");

            migrationBuilder.DropColumn(
                name: "SubFirstOfferId",
                table: "FirstOffers");
        }
    }
}
