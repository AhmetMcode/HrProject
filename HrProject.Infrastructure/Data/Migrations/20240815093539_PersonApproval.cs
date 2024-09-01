using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class PersonApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Personals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedById",
                table: "Personals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personals_ApprovedById",
                table: "Personals",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
    name: "FK_Personals_AspNetUsers_ApprovedById",
    table: "Personals",
    column: "ApprovedById",
    principalTable: "AspNetUsers",
    principalColumn: "Id",
    onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personals_AspNetUsers_ApprovedById",
                table: "Personals");

            migrationBuilder.DropIndex(
                name: "IX_Personals_ApprovedById",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Personals");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "Personals");
        }
    }
}
