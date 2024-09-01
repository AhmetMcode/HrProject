using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class adesss2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Stocks_StockId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Units_UnitId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_StockId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_UnitId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "OutWaybills2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OutWaybills2",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_StockId",
                table: "OutWaybills2",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_UnitId",
                table: "OutWaybills2",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Stocks_StockId",
                table: "OutWaybills2",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Units_UnitId",
                table: "OutWaybills2",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
