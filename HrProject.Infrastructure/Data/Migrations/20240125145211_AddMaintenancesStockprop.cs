using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenancesStockprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks",
                column: "MaintenanceServiceId",
                principalTable: "MaintenanceServices",
                principalColumn: "Id");
        }
    }
}
