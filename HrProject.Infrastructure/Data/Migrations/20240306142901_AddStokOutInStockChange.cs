using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStokOutInStockChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutStocksOrNot",
                table: "Invoices");

            migrationBuilder.AddColumn<bool>(
                name: "OutStocksOrNot",
                table: "InvoiceStocks",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutStocksOrNot",
                table: "InvoiceStocks");

            migrationBuilder.AddColumn<bool>(
                name: "OutStocksOrNot",
                table: "Invoices",
                type: "bit",
                nullable: true);
        }
    }
}
