using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleInMeintanenceervice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_VehicleCategories_VehicleCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.RenameColumn(
                name: "VehicleCategoryId",
                table: "MaintenanceServices",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceServices_VehicleCategoryId",
                table: "MaintenanceServices",
                newName: "IX_MaintenanceServices_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleCategory",
                table: "MaintenanceServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancesStocks_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_Vehicles_VehicleId",
                table: "MaintenanceServices",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_Vehicles_VehicleId",
                table: "MaintenanceServices");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancesStocks_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropColumn(
                name: "VehicleCategory",
                table: "MaintenanceServices");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "MaintenanceServices",
                newName: "VehicleCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceServices_VehicleId",
                table: "MaintenanceServices",
                newName: "IX_MaintenanceServices_VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_VehicleCategories_VehicleCategoryId",
                table: "MaintenanceServices",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
