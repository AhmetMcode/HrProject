using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class qualityforumsubanswerrrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualityFormSubAnswerId",
                table: "QuestionAnswer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DokumanTarihi",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonatiSinifi",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KalipNo",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MusteriAdi",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrunAdedi",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QualityFormSubAnswerId",
                table: "QuestionAnswer",
                column: "QualityFormSubAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_QualityFormSubAnswer_QualityFormSubAnswerId",
                table: "QuestionAnswer",
                column: "QualityFormSubAnswerId",
                principalTable: "QualityFormSubAnswer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_QualityFormSubAnswer_QualityFormSubAnswerId",
                table: "QuestionAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswer_QualityFormSubAnswerId",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "QualityFormSubAnswerId",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "DokumanTarihi",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "DonatiSinifi",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "KalipNo",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "MusteriAdi",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "UrunAdedi",
                table: "QualityFormSubAnswer");
        }
    }
}
