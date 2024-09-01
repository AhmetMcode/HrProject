using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class nildirimbaslik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BildirimBaslik",
                table: "ProductStepNotifs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BildirimIcerik",
                table: "ProductStepNotifs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BildirimBaslik",
                table: "ProductStepNotifs");

            migrationBuilder.DropColumn(
                name: "BildirimIcerik",
                table: "ProductStepNotifs");
        }
    }
}
