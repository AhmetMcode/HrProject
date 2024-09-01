using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenanceRequestListServiceService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MaintenanceRequestListServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceServiceId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceRequestId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequestListServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRequestListServices_MaintenanceRequests_MaintenanceRequestId",
                        column: x => x.MaintenanceRequestId,
                        principalTable: "MaintenanceRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceRequestListServices_MaintenanceServices_MaintenanceServiceId",
                        column: x => x.MaintenanceServiceId,
                        principalTable: "MaintenanceServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequestListServices_MaintenanceRequestId",
                table: "MaintenanceRequestListServices",
                column: "MaintenanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequestListServices_MaintenanceServiceId",
                table: "MaintenanceRequestListServices",
                column: "MaintenanceServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRequestListServices");

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
    }
}
