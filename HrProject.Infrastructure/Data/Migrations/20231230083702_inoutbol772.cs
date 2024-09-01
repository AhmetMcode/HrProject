using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class inoutbol772 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AcceptUserId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "AcceptUserId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "StockChanges");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChange",
                table: "StockChanges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StockChangeEnum",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateChange",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "StockChangeEnum",
                table: "StockChanges");

            migrationBuilder.AddColumn<string>(
                name: "AcceptUserId",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizingUserId",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "StockChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AcceptUserId",
                table: "StockChanges",
                column: "AcceptUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AuthorizingUserId",
                table: "StockChanges",
                column: "AuthorizingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId",
                table: "StockChanges",
                column: "AcceptUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId",
                table: "StockChanges",
                column: "AuthorizingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
