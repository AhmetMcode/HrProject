using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullablebankdesc2 : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransfers_Account2Id",
                table: "MoneyTransfers");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransfers_Bank2Id",
                table: "MoneyTransfers");

            migrationBuilder.RenameColumn(
                name: "Bank2Id",
                table: "MoneyTransfers",
                newName: "Banks2Id");

            migrationBuilder.RenameColumn(
                name: "Account2Id",
                table: "MoneyTransfers",
                newName: "Accounts2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Banks2Id",
                table: "MoneyTransfers",
                newName: "Bank2Id");

            migrationBuilder.RenameColumn(
                name: "Accounts2Id",
                table: "MoneyTransfers",
                newName: "Account2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_Account2Id",
                table: "MoneyTransfers",
                column: "Account2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_Bank2Id",
                table: "MoneyTransfers",
                column: "Bank2Id");

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
    }
}
