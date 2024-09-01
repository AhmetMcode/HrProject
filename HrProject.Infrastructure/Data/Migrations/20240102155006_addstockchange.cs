using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addstockchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InWaybillId",
                table: "StockChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_InWaybillId",
                table: "StockChanges",
                column: "InWaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_InWaybills_InWaybillId",
                table: "StockChanges",
                column: "InWaybillId",
                principalTable: "InWaybills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_InWaybills_InWaybillId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_InWaybillId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "InWaybillId",
                table: "StockChanges");
        }
    }
}
