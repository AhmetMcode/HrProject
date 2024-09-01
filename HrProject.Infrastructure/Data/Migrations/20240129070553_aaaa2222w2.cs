using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaaa2222w2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LastStep",
                table: "ProductionStep",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ManifactStepTypeId",
                table: "ProductionStep",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStep_ManifactStepTypeId",
                table: "ProductionStep",
                column: "ManifactStepTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStep_ManifactStepTypes_ManifactStepTypeId",
                table: "ProductionStep",
                column: "ManifactStepTypeId",
                principalTable: "ManifactStepTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStep_ManifactStepTypes_ManifactStepTypeId",
                table: "ProductionStep");

            migrationBuilder.DropIndex(
                name: "IX_ProductionStep_ManifactStepTypeId",
                table: "ProductionStep");

            migrationBuilder.DropColumn(
                name: "LastStep",
                table: "ProductionStep");

            migrationBuilder.DropColumn(
                name: "ManifactStepTypeId",
                table: "ProductionStep");
        }
    }
}
