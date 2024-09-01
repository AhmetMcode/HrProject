using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class holnesne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HolNesne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Genlisik = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uzunluk = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionPlaceId = table.Column<int>(type: "int", nullable: false),
                    Top = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Left = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolNesne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolNesne_ProductionPlaces_ProductionPlaceId",
                        column: x => x.ProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolNesne_ProductionPlaceId",
                table: "HolNesne",
                column: "ProductionPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HolNesne");
        }
    }
}
