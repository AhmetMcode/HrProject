using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stockpast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockPasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockChangeId = table.Column<int>(type: "int", nullable: false),
                    OutWaybill2Id = table.Column<int>(type: "int", nullable: false),
                    InWaybillId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockPasts_InWaybills_InWaybillId",
                        column: x => x.InWaybillId,
                        principalTable: "InWaybills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockPasts_OutWaybills2_OutWaybill2Id",
                        column: x => x.OutWaybill2Id,
                        principalTable: "OutWaybills2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockPasts_StockChanges_StockChangeId",
                        column: x => x.StockChangeId,
                        principalTable: "StockChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockPasts_InWaybillId",
                table: "StockPasts",
                column: "InWaybillId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPasts_OutWaybill2Id",
                table: "StockPasts",
                column: "OutWaybill2Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockPasts_StockChangeId",
                table: "StockPasts",
                column: "StockChangeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockPasts");
        }
    }
}
