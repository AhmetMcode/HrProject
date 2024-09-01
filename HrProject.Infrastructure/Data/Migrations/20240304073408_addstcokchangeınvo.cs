using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addstcokchangeınvo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceStocks_StockId",
                table: "InvoiceStocks");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "InvoiceStocks");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceStockId",
                table: "StockChanges",
                type: "int",
                nullable: true);



            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_InvoiceStockId",
                table: "StockChanges",
                column: "InvoiceStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_InvoiceStocks_InvoiceStockId",
                table: "StockChanges",
                column: "InvoiceStockId",
                principalTable: "InvoiceStocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_InvoiceStocks_InvoiceStockId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_InvoiceStockId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "InvoiceStockId",
                table: "StockChanges");



            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "InvoiceStocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStocks_StockId",
                table: "InvoiceStocks",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }
    }
}
