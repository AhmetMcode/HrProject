using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stocksubb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockSubId",
                table: "StockChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryWareHouseId = table.Column<int>(type: "int", nullable: true),
                    ExitWareHouseId = table.Column<int>(type: "int", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockSub_WareHouses_EntryWareHouseId",
                        column: x => x.EntryWareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockSub_WareHouses_ExitWareHouseId",
                        column: x => x.ExitWareHouseId,
                        principalTable: "WareHouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockChanges_StockSubId",
                table: "StockChanges",
                column: "StockSubId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSub_EntryWareHouseId",
                table: "StockSub",
                column: "EntryWareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSub_ExitWareHouseId",
                table: "StockSub",
                column: "ExitWareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockChanges_StockSub_StockSubId",
                table: "StockChanges",
                column: "StockSubId",
                principalTable: "StockSub",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockChanges_StockSub_StockSubId",
                table: "StockChanges");

            migrationBuilder.DropTable(
                name: "StockSub");

            migrationBuilder.DropIndex(
                name: "IX_StockChanges_StockSubId",
                table: "StockChanges");

            migrationBuilder.DropColumn(
                name: "StockSubId",
                table: "StockChanges");
        }
    }
}
