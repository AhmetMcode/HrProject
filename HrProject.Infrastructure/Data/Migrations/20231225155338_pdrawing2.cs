using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pdrawing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectProcessStage",
                table: "ProductionDrawings");

            migrationBuilder.AddColumn<string>(
                name: "StageName",
                table: "ProductionDrawings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StageName",
                table: "ProductionDrawings");

            migrationBuilder.AddColumn<int>(
                name: "ProjectProcessStage",
                table: "ProductionDrawings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
