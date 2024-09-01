using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class SonTeklif : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "DetailOffers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DetailOffers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DetailOffers");

            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "DetailOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
