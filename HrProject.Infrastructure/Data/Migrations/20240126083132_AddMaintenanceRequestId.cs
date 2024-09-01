using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceRequestId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequestListServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceRequestListServices");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceRequestId",
                table: "MaintenanceRequestListServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequestListServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceRequestListServices",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequestListServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceRequestListServices");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceRequestId",
                table: "MaintenanceRequestListServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequestListServices_MaintenanceRequests_MaintenanceRequestId",
                table: "MaintenanceRequestListServices",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");
        }
    }
}
