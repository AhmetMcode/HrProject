using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class permissionModifed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonlId",
                table: "PersonPermissions");

            migrationBuilder.RenameColumn(
                name: "NUmberOfDays",
                table: "PersonPermissionTypes",
                newName: "NumberOfDays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfDays",
                table: "PersonPermissionTypes",
                newName: "NUmberOfDays");

            migrationBuilder.AddColumn<int>(
                name: "PersonlId",
                table: "PersonPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
