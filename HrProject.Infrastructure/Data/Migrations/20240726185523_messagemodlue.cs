using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class messagemodlue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {




            migrationBuilder.CreateTable(
                name: "MessageModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GonderilmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Belge = table.Column<bool>(type: "bit", nullable: false),
                    GrupMesajı = table.Column<bool>(type: "bit", nullable: false),
                    BelgeBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelgeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelgeBaseUzanti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanId = table.Column<string>(type: "nvarchar(450)", nullable: true),

                    Iletildi = table.Column<bool>(type: "bit", nullable: false),
                    Goruldu = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageModule_AspNetUsers_AlanId",
                        column: x => x.AlanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageModule_AspNetUsers_GonderenId",
                        column: x => x.GonderenId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                });





            migrationBuilder.CreateIndex(
                name: "IX_MessageModule_AlanId",
                table: "MessageModule",
                column: "AlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageModule_GonderenId",
                table: "MessageModule",
                column: "GonderenId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "MessageModule");

            migrationBuilder.DropTable(
                name: "MessageGroup");
        }
    }
}
