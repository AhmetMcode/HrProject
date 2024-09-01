using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class qualityformsub2aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualityFormSubId",
                table: "ProductionStep",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStep_QualityFormSubId",
                table: "ProductionStep",
                column: "QualityFormSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionStep_QualityFormSub_QualityFormSubId",
                table: "ProductionStep",
                column: "QualityFormSubId",
                principalTable: "QualityFormSub",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionStep_QualityFormSub_QualityFormSubId",
                table: "ProductionStep");

            migrationBuilder.DropIndex(
                name: "IX_ProductionStep_QualityFormSubId",
                table: "ProductionStep");

            migrationBuilder.DropColumn(
                name: "QualityFormSubId",
                table: "ProductionStep");
        }
    }
}
