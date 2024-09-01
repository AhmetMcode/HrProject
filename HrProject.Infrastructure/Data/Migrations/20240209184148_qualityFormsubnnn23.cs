using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class qualityFormsubnnn23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityFormSubAnswer_PmCalculates_PmCalculateId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_QualityFormSubAnswer_ProjectModuleSub_ProjectModuleSubId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QualityFormSubAnswer_PmCalculateId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropIndex(
                name: "IX_QualityFormSubAnswer_ProjectModuleSubId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "PmCalculateId",
                table: "QualityFormSubAnswer");

            migrationBuilder.DropColumn(
                name: "ProjectModuleSubId",
                table: "QualityFormSubAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionStepId",
                table: "QualityFormSub",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "QualityFormSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub",
                column: "ProductionStepId",
                principalTable: "ProductionStep",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "QualityFormSub");

            migrationBuilder.AddColumn<int>(
                name: "PmCalculateId",
                table: "QualityFormSubAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectModuleSubId",
                table: "QualityFormSubAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionStepId",
                table: "QualityFormSub",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_PmCalculateId",
                table: "QualityFormSubAnswer",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_ProjectModuleSubId",
                table: "QualityFormSubAnswer",
                column: "ProjectModuleSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                table: "QualityFormSub",
                column: "ProductionStepId",
                principalTable: "ProductionStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityFormSubAnswer_PmCalculates_PmCalculateId",
                table: "QualityFormSubAnswer",
                column: "PmCalculateId",
                principalTable: "PmCalculates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualityFormSubAnswer_ProjectModuleSub_ProjectModuleSubId",
                table: "QualityFormSubAnswer",
                column: "ProjectModuleSubId",
                principalTable: "ProjectModuleSub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
