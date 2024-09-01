using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteaccount2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_Account2Id",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Account2Id",
                table: "Invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Account2Id",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Account2Id",
                table: "Invoices",
                column: "Account2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices",
                column: "Account2Id",
                principalTable: "Accounts2",
                principalColumn: "Id");
        }
    }
}
