using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aaaa22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts_PmCalculates_PmCalculateId",
                table: "ProductManifacts");

            migrationBuilder.DropIndex(
                name: "IX_ProductManifacts_PmCalculateId",
                table: "ProductManifacts");

            migrationBuilder.DropColumn(
                name: "PmCalculateId",
                table: "ProductManifacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PmCalculateId",
                table: "ProductManifacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts_PmCalculateId",
                table: "ProductManifacts",
                column: "PmCalculateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts_PmCalculates_PmCalculateId",
                table: "ProductManifacts",
                column: "PmCalculateId",
                principalTable: "PmCalculates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
