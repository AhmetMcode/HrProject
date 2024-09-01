using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStockCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_GoodsCodes_GoodsCodeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SaleVatId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "SaleDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Stocks",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseVatId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GoodsCodeId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_GoodsCodes_GoodsCodeId",
                table: "Stocks",
                column: "GoodsCodeId",
                principalTable: "GoodsCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks",
                column: "PurchaseVatId",
                principalTable: "PurchaseVats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks",
                column: "SaleVatId",
                principalTable: "SaleVats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_GoodsCodes_GoodsCodeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Stocks");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleVatId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SaleDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseVatId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoodsCodeId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_GoodsCodes_GoodsCodeId",
                table: "Stocks",
                column: "GoodsCodeId",
                principalTable: "GoodsCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks",
                column: "PurchaseVatId",
                principalTable: "PurchaseVats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks",
                column: "SaleVatId",
                principalTable: "SaleVats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Units_UnitId",
                table: "Stocks",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
