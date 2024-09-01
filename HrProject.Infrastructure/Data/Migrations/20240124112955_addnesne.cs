using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnesne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MaintenanceRequestId",
                table: "MaintenanceServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceServices_MaintenanceRequestId",
                table: "MaintenanceServices",
                column: "MaintenanceRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceServices",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_MaintenanceRequestId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "MaintenanceRequestId",
                table: "MaintenanceServices");

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
    }
}
