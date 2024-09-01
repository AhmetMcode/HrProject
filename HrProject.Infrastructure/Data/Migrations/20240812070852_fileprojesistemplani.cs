using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class fileprojesistemplani : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul");

            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectModuleSub_ProjectModuleSubId",
                table: "FileProjeModul");



            migrationBuilder.AlterColumn<int>(
                name: "ProjectModuleSubId",
                table: "FileProjeModul",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectElementId",
                table: "FileProjeModul",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectModuleSub_ProjectModuleSubId",
                table: "FileProjeModul",
                column: "ProjectModuleSubId",
                principalTable: "ProjectModuleSub",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul");

            migrationBuilder.DropForeignKey(
                name: "FK_FileProjeModul_ProjectModuleSub_ProjectModuleSubId",
                table: "FileProjeModul");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectModuleSubId",
                table: "FileProjeModul",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectElementId",
                table: "FileProjeModul",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectElements_ProjectElementId",
                table: "FileProjeModul",
                column: "ProjectElementId",
                principalTable: "ProjectElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileProjeModul_ProjectModuleSub_ProjectModuleSubId",
                table: "FileProjeModul",
                column: "ProjectModuleSubId",
                principalTable: "ProjectModuleSub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
