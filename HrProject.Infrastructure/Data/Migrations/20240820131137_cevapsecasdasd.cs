using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class cevapsecasdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "QuestionAnswer");

            migrationBuilder.AddColumn<int>(
                name: "IlkKontrolCevap",
                table: "QuestionAnswer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SonKontrolCevap",
                table: "QuestionAnswer",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlkKontrolCevap",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "SonKontrolCevap",
                table: "QuestionAnswer");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "QuestionAnswer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
