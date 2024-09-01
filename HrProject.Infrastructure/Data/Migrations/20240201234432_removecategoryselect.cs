using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class removecategoryselect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_MaintenanceServiceCategories_MaintenanceServiceCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_MaintenanceServiceCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceCategoryId",
                table: "MaintenanceServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceCategoryId",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_MaintenanceServiceCategoryId",
                table: "MaintenanceServices",
                column: "MaintenanceServiceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_MaintenanceServiceCategories_MaintenanceServiceCategoryId",
                table: "MaintenanceServices",
                column: "MaintenanceServiceCategoryId",
                principalTable: "MaintenanceServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
