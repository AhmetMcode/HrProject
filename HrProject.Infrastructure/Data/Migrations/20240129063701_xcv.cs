using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class xcv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dailies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => x.Id);
                });





            migrationBuilder.CreateIndex(
                name: "IX_Menus_DailyId",
                table: "Menus",
                column: "DailyId");



            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Dailies_DailyId",
                table: "Menus",
                column: "DailyId",
                principalTable: "Dailies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Dailies_DailyId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Dailies");

            migrationBuilder.DropIndex(
                name: "IX_Menus_DailyId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DailyId",
                table: "Menus");
        }
    }
}
