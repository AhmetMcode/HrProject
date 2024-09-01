using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class baseoffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesBaseOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalesBaseOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOfferId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralVATTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeneralTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesBaseOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesBaseOffers_SalesOffers_SalesOfferId",
                        column: x => x.SalesOfferId,
                        principalTable: "SalesOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailOffers_SalesBaseOfferId",
                table: "SalesDetailOffers",
                column: "SalesBaseOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesBaseOffers_SalesOfferId",
                table: "SalesBaseOffers",
                column: "SalesOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers",
                column: "SalesBaseOfferId",
                principalTable: "SalesBaseOffers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropTable(
                name: "SalesBaseOffers");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailOffers_SalesBaseOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropColumn(
                name: "SalesBaseOfferId",
                table: "SalesDetailOffers");
        }
    }
}
