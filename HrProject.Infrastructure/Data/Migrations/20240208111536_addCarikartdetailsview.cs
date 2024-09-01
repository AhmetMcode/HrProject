using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCarikartdetailsview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariKartId",
                table: "MoneyTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_CariKartId",
                table: "MoneyTransfers",
                column: "CariKartId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransfers_CariKartId",
                table: "MoneyTransfers");

            migrationBuilder.DropColumn(
                name: "CariKartId",
                table: "MoneyTransfers");
        }
    }
}
