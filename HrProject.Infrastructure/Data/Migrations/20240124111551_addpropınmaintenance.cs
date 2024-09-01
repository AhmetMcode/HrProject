using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addpropınmaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_MaintenanceServiceId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceId",
                table: "MaintenanceRequests");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceRequestId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancesStocks_MaintenanceRequestId",
                table: "MaintenancesStocks",
                column: "MaintenanceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenancesStocks",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenancesStocks");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancesStocks_MaintenanceRequestId",
                table: "MaintenancesStocks");

            migrationBuilder.DropColumn(
                name: "MaintenanceRequestId",
                table: "MaintenancesStocks");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceServiceId",
                table: "MaintenanceRequests",
                column: "MaintenanceServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenanceRequests",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
