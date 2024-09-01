using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class carikart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OtherCariRisks_CariKartId",
                table: "OtherCariRisks");

            migrationBuilder.DropIndex(
                name: "IX_CariRisks_CariKartId",
                table: "CariRisks");

            migrationBuilder.AddColumn<int>(
                name: "CariBankId",
                table: "CariKarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OtherCariRisks_CariKartId",
                table: "OtherCariRisks",
                column: "CariKartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariRisks_CariKartId",
                table: "CariRisks",
                column: "CariKartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CariKarts_CariBankId",
                table: "CariKarts",
                column: "CariBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_CariKarts_CariBanks_CariBankId",
                table: "CariKarts",
                column: "CariBankId",
                principalTable: "CariBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariKarts_CariBanks_CariBankId",
                table: "CariKarts");

            migrationBuilder.DropIndex(
                name: "IX_OtherCariRisks_CariKartId",
                table: "OtherCariRisks");

            migrationBuilder.DropIndex(
                name: "IX_CariRisks_CariKartId",
                table: "CariRisks");

            migrationBuilder.DropIndex(
                name: "IX_CariKarts_CariBankId",
                table: "CariKarts");

            migrationBuilder.DropColumn(
                name: "CariBankId",
                table: "CariKarts");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCariRisks_CariKartId",
                table: "OtherCariRisks",
                column: "CariKartId");

            migrationBuilder.CreateIndex(
                name: "IX_CariRisks_CariKartId",
                table: "CariRisks",
                column: "CariKartId");
        }
    }
}
