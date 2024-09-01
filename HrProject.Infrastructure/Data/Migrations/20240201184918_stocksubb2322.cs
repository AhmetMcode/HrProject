using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stocksubb2322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_Personals_TeslimAlanId",
                table: "StockSub");

            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_Personals_TeslimEdenId",
                table: "StockSub");

            migrationBuilder.AlterColumn<int>(
                name: "TeslimEdenId",
                table: "StockSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TeslimAlanId",
                table: "StockSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_Personals_TeslimAlanId",
                table: "StockSub",
                column: "TeslimAlanId",
                principalTable: "Personals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_Personals_TeslimEdenId",
                table: "StockSub",
                column: "TeslimEdenId",
                principalTable: "Personals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_Personals_TeslimAlanId",
                table: "StockSub");

            migrationBuilder.DropForeignKey(
                name: "FK_StockSub_Personals_TeslimEdenId",
                table: "StockSub");

            migrationBuilder.AlterColumn<int>(
                name: "TeslimEdenId",
                table: "StockSub",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeslimAlanId",
                table: "StockSub",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_Personals_TeslimAlanId",
                table: "StockSub",
                column: "TeslimAlanId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockSub_Personals_TeslimEdenId",
                table: "StockSub",
                column: "TeslimEdenId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
