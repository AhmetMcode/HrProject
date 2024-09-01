using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addStockColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VATRateCode",
                table: "SaleVats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WithHRateCode",
                table: "SalesWithholdingRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VATRateCode",
                table: "PurchaseVats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WithHRateCode",
                table: "BuyingWithholdingRates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VATRateCode",
                table: "SaleVats");

            migrationBuilder.DropColumn(
                name: "WithHRateCode",
                table: "SalesWithholdingRates");

            migrationBuilder.DropColumn(
                name: "VATRateCode",
                table: "PurchaseVats");

            migrationBuilder.DropColumn(
                name: "WithHRateCode",
                table: "BuyingWithholdingRates");
        }
    }
}
