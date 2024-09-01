using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Dailies_DailyId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_DailyId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "DailyId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Meals");

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

            migrationBuilder.CreateIndex(
                name: "IX_DailyMenu_MenusId",
                table: "DailyMenu",
                column: "MenusId");

            migrationBuilder.CreateIndex(
                name: "IX_MealMenu_MenusId",
                table: "MealMenu",
                column: "MenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMenu");

            migrationBuilder.DropTable(
                name: "MealMenu");

            migrationBuilder.AddColumn<int>(
                name: "DailyId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_DailyId",
                table: "Menus",
                column: "DailyId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuId",
                table: "Meals",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Dailies_DailyId",
                table: "Menus",
                column: "DailyId",
                principalTable: "Dailies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
