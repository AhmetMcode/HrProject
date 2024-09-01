using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class formsonnn22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub");

            migrationBuilder.DropIndex(
                name: "IX_QualityFormSub_ProductionStepId",
                table: "QualityFormSub");

            migrationBuilder.DropColumn(
                name: "ProductionStepId",
                table: "QualityFormSub");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "QuestionAnswer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductManifactsId",
                table: "QualityFormSubAnswer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BetonDemirTipi",
                table: "QualityFormSub",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "QualityFormSub",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "ProductManifactsId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "BetonDemirTipi",
                table: "QualityFormSub");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "QualityFormSub");

            migrationBuilder.AddColumn<int>(
                name: "ProductionStepId",
                table: "QualityFormSub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSub_ProductionStepId",
                table: "QualityFormSub",
                column: "ProductionStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub",
                column: "ProductionStepId",
                principalTable: "ProductionStep",
                principalColumn: "Id");
        }
    }
}
