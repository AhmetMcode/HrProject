using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullablebank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_Accounts2_Account2Id",
                table: "MoneyTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_Banks2_Bank2Id",
                table: "MoneyTransfers");

            migrationBuilder.AlterColumn<int>(
                name: "Bank2Id",
                table: "MoneyTransfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Account2Id",
                table: "MoneyTransfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_Accounts2_Account2Id",
                table: "MoneyTransfers",
                column: "Account2Id",
                principalTable: "Accounts2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_Banks2_Bank2Id",
                table: "MoneyTransfers",
                column: "Bank2Id",
                principalTable: "Banks2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_Accounts2_Account2Id",
                table: "MoneyTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_Banks2_Bank2Id",
                table: "MoneyTransfers");

            migrationBuilder.AlterColumn<int>(
                name: "Bank2Id",
                table: "MoneyTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Account2Id",
                table: "MoneyTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_Accounts2_Account2Id",
                table: "MoneyTransfers",
                column: "Account2Id",
                principalTable: "Accounts2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_Banks2_Bank2Id",
                table: "MoneyTransfers",
                column: "Bank2Id",
                principalTable: "Banks2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
