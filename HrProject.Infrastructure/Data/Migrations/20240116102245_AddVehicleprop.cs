using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Personals_PersonId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BackupResponsible",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MainResponsible",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Vehicles",
                newName: "MainResponsibleId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_PersonId",
                table: "Vehicles",
                newName: "IX_Vehicles_MainResponsibleId");

            migrationBuilder.AddColumn<int>(
                name: "BackupResponsibleId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BackupResponsibleId",
                table: "Vehicles",
                column: "BackupResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Personals_BackupResponsibleId",
                table: "Vehicles",
                column: "BackupResponsibleId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Personals_MainResponsibleId",
                table: "Vehicles",
                column: "MainResponsibleId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Personals_BackupResponsibleId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Personals_MainResponsibleId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_BackupResponsibleId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BackupResponsibleId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "MainResponsibleId",
                table: "Vehicles",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_MainResponsibleId",
                table: "Vehicles",
                newName: "IX_Vehicles_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "BackupResponsible",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainResponsible",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Personals_PersonId",
                table: "Vehicles",
                column: "PersonId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
