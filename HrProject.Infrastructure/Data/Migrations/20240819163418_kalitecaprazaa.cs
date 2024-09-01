using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class kalitecaprazaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KaliteBirimAtama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionPlaceId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KaliteBirimAtama", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KaliteBirimAtama_ProductionPlaces_ProductionPlaceId",
                        column: x => x.ProductionPlaceId,
                        principalTable: "ProductionPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KaliteBirimAtamaIlkKontrolUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaliteBirimAtamaId = table.Column<int>(type: "int", nullable: false),
                    IlkKontrolUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KaliteBirimAtamaIlkKontrolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KaliteBirimAtamaIlkKontrolUser_AspNetUsers_IlkKontrolUserId",
                        column: x => x.IlkKontrolUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KaliteBirimAtamaIlkKontrolUser_KaliteBirimAtama_KaliteBirimAtamaId",
                        column: x => x.KaliteBirimAtamaId,
                        principalTable: "KaliteBirimAtama",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KaliteBirimAtamaSonKontrolUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KaliteBirimAtamaId = table.Column<int>(type: "int", nullable: false),
                    SonKontrolUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KaliteBirimAtamaSonKontrolUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KaliteBirimAtamaSonKontrolUser_AspNetUsers_SonKontrolUserId",
                        column: x => x.SonKontrolUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KaliteBirimAtamaSonKontrolUser_KaliteBirimAtama_KaliteBirimAtamaId",
                        column: x => x.KaliteBirimAtamaId,
                        principalTable: "KaliteBirimAtama",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KaliteBirimAtama_ProductionPlaceId",
                table: "KaliteBirimAtama",
                column: "ProductionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_KaliteBirimAtamaIlkKontrolUser_IlkKontrolUserId",
                table: "KaliteBirimAtamaIlkKontrolUser",
                column: "IlkKontrolUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KaliteBirimAtamaIlkKontrolUser_KaliteBirimAtamaId",
                table: "KaliteBirimAtamaIlkKontrolUser",
                column: "KaliteBirimAtamaId");

            migrationBuilder.CreateIndex(
                name: "IX_KaliteBirimAtamaSonKontrolUser_KaliteBirimAtamaId",
                table: "KaliteBirimAtamaSonKontrolUser",
                column: "KaliteBirimAtamaId");

            migrationBuilder.CreateIndex(
                name: "IX_KaliteBirimAtamaSonKontrolUser_SonKontrolUserId",
                table: "KaliteBirimAtamaSonKontrolUser",
                column: "SonKontrolUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KaliteBirimAtamaIlkKontrolUser");

            migrationBuilder.DropTable(
                name: "KaliteBirimAtamaSonKontrolUser");

            migrationBuilder.DropTable(
                name: "KaliteBirimAtama");
        }
    }
}
