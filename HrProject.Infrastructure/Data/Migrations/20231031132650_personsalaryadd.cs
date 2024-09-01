using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class personsalaryadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_PersonSalary_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSalary",
                table: "PersonSalary");

            migrationBuilder.RenameTable(
                name: "PersonSalary",
                newName: "PersonSalaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSalaries",
                table: "PersonSalaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personals_PersonSalaries_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId",
                principalTable: "PersonSalaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_PersonSalaries_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonSalaries",
                table: "PersonSalaries");

            migrationBuilder.RenameTable(
                name: "PersonSalaries",
                newName: "PersonSalary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonSalary",
                table: "PersonSalary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personals_PersonSalary_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId",
                principalTable: "PersonSalary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
