using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeporp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancesStocks_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.AddColumn<int>(
                name: "VehicleCategoryId",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_VehicleCategoryId",
                table: "MaintenanceServices",
                column: "VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_VehicleCategories_VehicleCategoryId",
                table: "MaintenanceServices",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_VehicleCategories_VehicleCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_VehicleCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "VehicleCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancesStocks_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id");
        }
    }
}
