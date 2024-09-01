using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class fileuploadlog1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploadLog_ProjectModuleSub_ProjectModuleSubId",
                table: "FileUploadLog");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectModuleSubId",
                table: "FileUploadLog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploadLog_ProjectModuleSub_ProjectModuleSubId",
                table: "FileUploadLog",
                column: "ProjectModuleSubId",
                principalTable: "ProjectModuleSub",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploadLog_ProjectModuleSub_ProjectModuleSubId",
                table: "FileUploadLog");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectModuleSubId",
                table: "FileUploadLog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploadLog_ProjectModuleSub_ProjectModuleSubId",
                table: "FileUploadLog",
                column: "ProjectModuleSubId",
                principalTable: "ProjectModuleSub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
