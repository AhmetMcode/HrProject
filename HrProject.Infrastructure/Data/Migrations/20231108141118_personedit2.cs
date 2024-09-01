using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class personedit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_PersonSalaries_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropIndex(
                name: "IX_Personals_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "PersonSalaryId",
                table: "Personals");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PersonSalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PersonSalaries_PersonId",
                table: "PersonSalaries",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonSalaries_Personals_PersonId",
                table: "PersonSalaries",
                column: "PersonId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonSalaries_Personals_PersonId",
                table: "PersonSalaries");

            migrationBuilder.DropIndex(
                name: "IX_PersonSalaries_PersonId",
                table: "PersonSalaries");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PersonSalaries");

            migrationBuilder.AddColumn<int>(
                name: "PersonSalaryId",
                table: "Personals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personals_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personals_PersonSalaries_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId",
                principalTable: "PersonSalaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
