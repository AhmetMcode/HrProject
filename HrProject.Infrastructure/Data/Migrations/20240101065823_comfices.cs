using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class comfices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContractConfirm",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ContractConfirmDesc",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContractConfirmFile",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractConfirmPrice",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContractConfirmRedDesc",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractConfirm",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmDesc",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmFile",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmPrice",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ContractConfirmRedDesc",
                table: "Offers");
        }
    }
}
