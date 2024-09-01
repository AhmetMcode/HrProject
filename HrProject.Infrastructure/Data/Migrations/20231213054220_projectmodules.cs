using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class projectmodules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_RecipentUserId",
                table: "ProjectModuleStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_ResponsibleUserId",
                table: "ProjectModuleStatus");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "ProjectModuleStatus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RecipentUserId",
                table: "ProjectModuleStatus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "ProjectModuleStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "ProjectModuleStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ProjectModuleStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_RecipentUserId",
                table: "ProjectModuleStatus",
                column: "RecipentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_ResponsibleUserId",
                table: "ProjectModuleStatus",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_RecipentUserId",
                table: "ProjectModuleStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_ResponsibleUserId",
                table: "ProjectModuleStatus");

            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "ProjectModuleStatus");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "ProjectModuleStatus");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ProjectModuleStatus");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "ProjectModuleStatus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipentUserId",
                table: "ProjectModuleStatus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_RecipentUserId",
                table: "ProjectModuleStatus",
                column: "RecipentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModuleStatus_AspNetUsers_ResponsibleUserId",
                table: "ProjectModuleStatus",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
