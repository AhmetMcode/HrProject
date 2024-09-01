using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class modifedOfferProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferProcess_AspNetUsers_ResponsibleUserId",
                table: "OfferProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferProcess_AspNetUsers_StarterUserId",
                table: "OfferProcess");

            migrationBuilder.AlterColumn<string>(
                name: "StarterUserId",
                table: "OfferProcess",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "OfferProcess",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "OfferProcess",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferProcess_AspNetUsers_ResponsibleUserId",
                table: "OfferProcess",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferProcess_AspNetUsers_StarterUserId",
                table: "OfferProcess",
                column: "StarterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferProcess_AspNetUsers_ResponsibleUserId",
                table: "OfferProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferProcess_AspNetUsers_StarterUserId",
                table: "OfferProcess");

            migrationBuilder.AlterColumn<string>(
                name: "StarterUserId",
                table: "OfferProcess",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResponsibleUserId",
                table: "OfferProcess",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "OfferProcess",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferProcess_AspNetUsers_ResponsibleUserId",
                table: "OfferProcess",
                column: "ResponsibleUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferProcess_AspNetUsers_StarterUserId",
                table: "OfferProcess",
                column: "StarterUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
