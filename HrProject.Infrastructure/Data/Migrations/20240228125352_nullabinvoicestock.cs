using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullabinvoicestock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_SaleVats_SaleVatId",
                table: "InvoiceStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Units_UnitId",
                table: "InvoiceStocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "InvoiceStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "InvoiceStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SaleVatId",
                table: "InvoiceStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_SaleVats_SaleVatId",
                table: "InvoiceStocks",
                column: "SaleVatId",
                principalTable: "SaleVats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Units_UnitId",
                table: "InvoiceStocks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_SaleVats_SaleVatId",
                table: "InvoiceStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Units_UnitId",
                table: "InvoiceStocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "InvoiceStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "InvoiceStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleVatId",
                table: "InvoiceStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_SaleVats_SaleVatId",
                table: "InvoiceStocks",
                column: "SaleVatId",
                principalTable: "SaleVats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Stocks_StockId",
                table: "InvoiceStocks",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Units_UnitId",
                table: "InvoiceStocks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
