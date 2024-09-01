using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stockk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSayim_AspNetUsers_ApplicationUserId1",
                table: "SubSayim");

            migrationBuilder.DropIndex(
                name: "IX_SubSayim_ApplicationUserId1",
                table: "SubSayim");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "SubSayim");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "SubSayim",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SubSayim_ApplicationUserId",
                table: "SubSayim",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSayim_AspNetUsers_ApplicationUserId",
                table: "SubSayim",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSayim_AspNetUsers_ApplicationUserId",
                table: "SubSayim");

            migrationBuilder.DropIndex(
                name: "IX_SubSayim_ApplicationUserId",
                table: "SubSayim");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "SubSayim",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "SubSayim",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SubSayim_ApplicationUserId1",
                table: "SubSayim",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSayim_AspNetUsers_ApplicationUserId1",
                table: "SubSayim",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
