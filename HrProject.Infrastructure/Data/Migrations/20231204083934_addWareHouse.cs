using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addWareHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_WareHouses_ExitWareHouseId",
                table: "StockChanges");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "WareHouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ExitWareHouseId",
                table: "StockChanges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EntryWareHouseId",
                table: "StockChanges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AuthorizingUserId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AuthorizingUserId1",
                table: "StockChanges",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "StockChanges",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "StockChanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_AuthorizingUserId1",
                table: "StockChanges",
                column: "AuthorizingUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId1",
                table: "StockChanges",
                column: "AuthorizingUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_WareHouses_ExitWareHouseId",
                table: "StockChanges",
                column: "ExitWareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_AspNetUsers_AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_WareHouses_ExitWareHouseId",
                table: "StockChanges");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "WareHouses");

            migrationBuilder.DropColumn(
                name: "AuthorizingUserId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "AuthorizingUserId1",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "StockChanges");

            migrationBuilder.AlterColumn<int>(
                name: "ExitWareHouseId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EntryWareHouseId",
                table: "StockChanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_WareHouses_ExitWareHouseId",
                table: "StockChanges",
                column: "ExitWareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
