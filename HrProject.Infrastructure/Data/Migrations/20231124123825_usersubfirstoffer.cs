using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class usersubfirstoffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StarterUserId",
                table: "SubFirstOffers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SubFirstOffers_StarterUserId",
                table: "SubFirstOffers",
                column: "StarterUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubFirstOffers_AspNetUsers_StarterUserId",
                table: "SubFirstOffers",
                column: "StarterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubFirstOffers_AspNetUsers_StarterUserId",
                table: "SubFirstOffers");

            migrationBuilder.DropIndex(
                name: "IX_SubFirstOffers_StarterUserId",
                table: "SubFirstOffers");

            migrationBuilder.DropColumn(
                name: "StarterUserId",
                table: "SubFirstOffers");
        }
    }
}
