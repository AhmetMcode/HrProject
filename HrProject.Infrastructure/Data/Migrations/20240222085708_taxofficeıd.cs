using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class taxofficeıd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariKarts_TaxOffices_TaxOfficeId",
                table: "CariKarts");

            migrationBuilder.AlterColumn<int>(
                name: "TaxOfficeId",
                table: "CariKarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CariKarts_TaxOffices_TaxOfficeId",
                table: "CariKarts",
                column: "TaxOfficeId",
                principalTable: "TaxOffices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariKarts_TaxOffices_TaxOfficeId",
                table: "CariKarts");

            migrationBuilder.AlterColumn<int>(
                name: "TaxOfficeId",
                table: "CariKarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CariKarts_TaxOffices_TaxOfficeId",
                table: "CariKarts",
                column: "TaxOfficeId",
                principalTable: "TaxOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
