using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerrespponsible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponsibleUserId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ResponsibleUserId",
                table: "Offers",
                column: "ResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_ResponsibleUserId",
                table: "Offers",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_ResponsibleUserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ResponsibleUserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                table: "Offers");
        }
    }
}
