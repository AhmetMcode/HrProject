using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class manyt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenu");

            migrationBuilder.DropTable(
                name: "MealMenu");

            migrationBuilder.DropTable(
                name: "Dailies");

            migrationBuilder.RenameColumn(
                name: "Existing",
                table: "Menus",
                newName: "PersonQuant");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MealId",
                table: "Menus",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Meals_MealId",
                table: "Menus",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Meals_MealId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_MealId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "PersonQuant",
                table: "Menus",
                newName: "Existing");

            migrationBuilder.CreateTable(
                name: "Dailies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dailies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealMenu",
                columns: table => new
                {
                    MealsId = table.Column<int>(type: "int", nullable: false),
                    MenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealMenu", x => new { x.MealsId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_MealMenu_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyMenu",
                columns: table => new
                {
                    DailiesId = table.Column<int>(type: "int", nullable: false),
                    MenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMenu", x => new { x.DailiesId, x.MenusId });
                    table.ForeignKey(
                        name: "FK_DailyMenu_Dailies_DailiesId",
                        column: x => x.DailiesId,
                        principalTable: "Dailies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyMenu_Menus_MenusId",
                        column: x => x.MenusId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenu_MenusId",
                table: "DailyMenu",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_MenusId",
                table: "MealMenu",
                column: "MenusId");
        }
    }
}
