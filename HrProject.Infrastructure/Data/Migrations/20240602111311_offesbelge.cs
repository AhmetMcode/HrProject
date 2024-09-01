using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offesbelge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ContractConfirmPrice",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContractConfirmFileOther",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractConfirmPriceGR",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractConfirmPriceKdvDahil",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractConfirmPriceKdvOrani",
                table: "Offers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractConfirmFileOther",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmPriceGR",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmPriceKdvDahil",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmPriceKdvOrani",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "ContractConfirmPrice",
                table: "Offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
