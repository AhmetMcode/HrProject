using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerdescs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescResponseCalculate",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescResponseProject",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LengthOfTermCalculate",
                table: "Offers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LengthOfTermProject",
                table: "Offers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectResponsibleUserId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProjectResponsibleUserId",
                table: "Offers",
                column: "ProjectResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_ProjectResponsibleUserId",
                table: "Offers",
                column: "ProjectResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_ProjectResponsibleUserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ProjectResponsibleUserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DescResponseCalculate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DescResponseProject",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LengthOfTermCalculate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LengthOfTermProject",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ProjectResponsibleUserId",
                table: "Offers");
        }
    }
}
