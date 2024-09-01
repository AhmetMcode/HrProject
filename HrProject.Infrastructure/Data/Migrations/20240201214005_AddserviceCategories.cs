using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddserviceCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlKm",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ControlRange",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceServiceCategoryId",
                table: "MaintenanceServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaintenanceServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceServiceCategories", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceServices_MaintenanceServiceCategories_MaintenanceServiceCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropTable(
                name: "MaintenanceServiceCategories");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceServices_MaintenanceServiceCategoryId",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "ControlKm",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "ControlRange",
                table: "MaintenanceServices");

            migrationBuilder.DropColumn(
                name: "MaintenanceServiceCategoryId",
                table: "MaintenanceServices");
        }
    }
}
