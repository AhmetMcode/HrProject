using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stockviewmodelnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "VariantDescription",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SalesWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalesWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EDocumentBaseRateId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuyingWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuyingWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks",
                column: "BuyingWithholdingRateId",
                principalTable: "BuyingWithholdingRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks",
                column: "BuyingWithholdingTypeId",
                principalTable: "BuyingWithholdingTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks",
                column: "EDocumentBaseRateId",
                principalTable: "EDocumentBaseRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks",
                column: "SalesWithholdingRateId",
                principalTable: "SalesWithholdingRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks",
                column: "SalesWithholdingTypeId",
                principalTable: "SalesWithholdingTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "VariantDescription",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EDocumentBaseRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyingWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyingWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks",
                column: "BuyingWithholdingRateId",
                principalTable: "BuyingWithholdingRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks",
                column: "BuyingWithholdingTypeId",
                principalTable: "BuyingWithholdingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks",
                column: "EDocumentBaseRateId",
                principalTable: "EDocumentBaseRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks",
                column: "SalesWithholdingRateId",
                principalTable: "SalesWithholdingRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks",
                column: "SalesWithholdingTypeId",
                principalTable: "SalesWithholdingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
