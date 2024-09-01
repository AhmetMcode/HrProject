using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class wer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesOffers_SalesOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailOffers_SalesOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropColumn(
                name: "SalesOfferId",
                table: "SalesDetailOffers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailOffers_SalesOfferId",
                table: "SalesDetailOffers",
                column: "SalesOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesOffers_SalesOfferId",
                table: "SalesDetailOffers",
                column: "SalesOfferId",
                principalTable: "SalesOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
