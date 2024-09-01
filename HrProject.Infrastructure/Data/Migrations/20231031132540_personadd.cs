using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class personadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Personals");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Personals",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "CriminalRecord",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diploma",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HealthReport",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonSalaryId",
                table: "Personals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfResidence",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PopulationRegistration",
                table: "Personals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSalary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personals_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personals_PersonSalary_PersonSalaryId",
                table: "Personals",
                column: "PersonSalaryId",
                principalTable: "PersonSalary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_PersonSalary_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropTable(
                name: "PersonSalary");

            migrationBuilder.DropIndex(
                name: "IX_Personals_PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "CriminalRecord",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "Diploma",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "HealthReport",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "PersonSalaryId",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "PlaceOfResidence",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "PopulationRegistration",
                table: "Personals");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Personals",
                newName: "FullName");

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "Personals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Personals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
