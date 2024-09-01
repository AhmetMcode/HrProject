using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ISG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISGSafetyIssue_AspNetUsers_ReportedById",
                table: "ISGSafetyIssue");

            migrationBuilder.DropIndex(
                name: "IX_ISGSafetyIssue_ReportedById",
                table: "ISGSafetyIssue");

            migrationBuilder.AlterColumn<string>(
                name: "ReportedById",
                table: "ISGSafetyIssue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "ISGSafetyIssue",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssue_PersonId",
                table: "ISGSafetyIssue",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ISGSafetyIssue_Personals_PersonId",
                table: "ISGSafetyIssue",
                column: "PersonId",
                principalTable: "Personals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ISGSafetyIssue_Personals_PersonId",
                table: "ISGSafetyIssue");

            migrationBuilder.DropIndex(
                name: "IX_ISGSafetyIssue_PersonId",
                table: "ISGSafetyIssue");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ISGSafetyIssue");

            migrationBuilder.AlterColumn<string>(
                name: "ReportedById",
                table: "ISGSafetyIssue",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssue_ReportedById",
                table: "ISGSafetyIssue",
                column: "ReportedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ISGSafetyIssue_AspNetUsers_ReportedById",
                table: "ISGSafetyIssue",
                column: "ReportedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
