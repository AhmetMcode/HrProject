using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockChangeVm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId1",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_WareHouses_WareHouseId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AcceptUserId1",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_WareHouseId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "AcceptUserId1",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "StockChanges");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorizingUserId",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AcceptUserId",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AcceptUserId",
                table: "StockChanges",
                column: "AcceptUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AuthorizingUserId",
                table: "StockChanges",
                column: "AuthorizingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_EntryWareHouseId",
                table: "StockChanges",
                column: "EntryWareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId",
                table: "StockChanges",
                column: "AcceptUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId",
                table: "StockChanges",
                column: "AuthorizingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_WareHouses_EntryWareHouseId",
                table: "StockChanges",
                column: "EntryWareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_WareHouses_EntryWareHouseId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AcceptUserId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_EntryWareHouseId",
                table: "StockChanges");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorizingUserId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "AcceptUserId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AcceptUserId1",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizingUserId1",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AcceptUserId1",
                table: "StockChanges",
                column: "AcceptUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AuthorizingUserId1",
                table: "StockChanges",
                column: "AuthorizingUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_WareHouseId",
                table: "StockChanges",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AcceptUserId1",
                table: "StockChanges",
                column: "AcceptUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId1",
                table: "StockChanges",
                column: "AuthorizingUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_WareHouses_WareHouseId",
                table: "StockChanges",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
