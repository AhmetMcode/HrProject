using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCariKartProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountNo",
                table: "CariKarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyType",
                table: "CariKarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalBalance",
                table: "CariKarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstBalance",
                table: "CariKarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstBalanceDate",
                table: "CariKarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "CariKarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNo",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "CurrencyType",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "FinalBalance",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "FirstBalance",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "FirstBalanceDate",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "CariKarts");
        }
    }
}
