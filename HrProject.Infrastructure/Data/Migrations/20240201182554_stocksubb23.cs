using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stocksubb23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeslimAlanId",
                table: "StockSub",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeslimEdenId",
                table: "StockSub",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockSub_TeslimAlanId",
                table: "StockSub",
                column: "TeslimAlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSub_TeslimEdenId",
                table: "StockSub",
                column: "TeslimEdenId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_AspNetUsers_TeslimAlanId",
                table: "StockSub",
                column: "TeslimAlanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_AspNetUsers_TeslimEdenId",
                table: "StockSub",
                column: "TeslimEdenId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_AspNetUsers_TeslimAlanId",
                table: "StockSub");

            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_AspNetUsers_TeslimEdenId",
                table: "StockSub");

            migrationBuilder.DropIndex(
                name: "IX_StockSub_TeslimAlanId",
                table: "StockSub");

            migrationBuilder.DropIndex(
                name: "IX_StockSub_TeslimEdenId",
                table: "StockSub");

            migrationBuilder.DropColumn(
                name: "TeslimAlanId",
                table: "StockSub");

            migrationBuilder.DropColumn(
                name: "TeslimEdenId",
                table: "StockSub");
        }
    }
}
