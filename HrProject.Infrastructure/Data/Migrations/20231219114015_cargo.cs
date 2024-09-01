using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class cargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KargoCompany",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KargoTaxNumber",
                table: "OutWaybills2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelCars",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelNameDetails",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TasiyiciCars",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TasiyiciDriver",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TasiyiciTC",
                table: "OutWaybills2",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KargoCompany",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "KargoTaxNumber",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "PersonelCars",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "PersonelNameDetails",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "TasiyiciCars",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "TasiyiciDriver",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "TasiyiciTC",
                table: "OutWaybills2");
        }
    }
}
