using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class MaintenanceService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaintenanceServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServices", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenancesStocks_MaintenanceServices_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropTable(
                name: "MaintenanceServices");

            migrationBuilder.DropIndex(
                name: "IX_MaintenancesStocks_MaintenanceServiceId",
                table: "MaintenancesStocks");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceId",
                table: "MaintenancesStocks");
        }
    }
}
