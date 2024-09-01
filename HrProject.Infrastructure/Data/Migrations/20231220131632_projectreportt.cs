using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class projectreportt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArchProject",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerRequest",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroundReport",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchProject",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "CustomerRequest",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "GroundReport",
                table: "ProjectModuleSub");
        }
    }
}
