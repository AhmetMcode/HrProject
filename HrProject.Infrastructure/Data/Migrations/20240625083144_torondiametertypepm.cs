using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class torondiametertypepm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToronDiameterTypeId",
                table: "PmCalculates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmCalculates_ToronDiameterTypeId",
                table: "PmCalculates",
                column: "ToronDiameterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmCalculates_ToronDiameters_ToronDiameterTypeId",
                table: "PmCalculates",
                column: "ToronDiameterTypeId",
                principalTable: "ToronDiameters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmCalculates_ToronDiameters_ToronDiameterTypeId",
                table: "PmCalculates");

            migrationBuilder.DropIndex(
                name: "IX_PmCalculates_ToronDiameterTypeId",
                table: "PmCalculates");

            migrationBuilder.DropColumn(
                name: "ToronDiameterTypeId",
                table: "PmCalculates");
        }
    }
}
