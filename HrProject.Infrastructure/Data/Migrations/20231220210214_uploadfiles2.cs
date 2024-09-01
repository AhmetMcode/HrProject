using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uploadfiles2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploadLog_AspNetUsers_UploadUserIdId",
                table: "FileUploadLog");

            migrationBuilder.DropColumn(
                name: "UploadUser",
                table: "FileUploadLog");

            migrationBuilder.RenameColumn(
                name: "UploadUserIdId",
                table: "FileUploadLog",
                newName: "UploadUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FileUploadLog_UploadUserIdId",
                table: "FileUploadLog",
                newName: "IX_FileUploadLog_UploadUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploadLog_AspNetUsers_UploadUserId",
                table: "FileUploadLog",
                column: "UploadUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUploadLog_AspNetUsers_UploadUserId",
                table: "FileUploadLog");

            migrationBuilder.RenameColumn(
                name: "UploadUserId",
                table: "FileUploadLog",
                newName: "UploadUserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_FileUploadLog_UploadUserId",
                table: "FileUploadLog",
                newName: "IX_FileUploadLog_UploadUserIdId");

            migrationBuilder.AddColumn<string>(
                name: "UploadUser",
                table: "FileUploadLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUploadLog_AspNetUsers_UploadUserIdId",
                table: "FileUploadLog",
                column: "UploadUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
