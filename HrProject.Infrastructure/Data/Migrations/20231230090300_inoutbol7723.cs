using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class inoutbol7723 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutWaybill2Id",
                table: "StockChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_OutWaybill2Id",
                table: "StockChanges",
                column: "OutWaybill2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_OutWaybills2_OutWaybill2Id",
                table: "StockChanges",
                column: "OutWaybill2Id",
                principalTable: "OutWaybills2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_OutWaybills2_OutWaybill2Id",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_OutWaybill2Id",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "OutWaybill2Id",
                table: "StockChanges");
        }
    }
}
