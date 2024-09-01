using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class formsonnn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetonKontrolFormuCevaplari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerType = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetonKontrolFormuCevaplari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuCevaplari_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BetonKontrolFormuSorulari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiraNo = table.Column<int>(type: "int", nullable: false),
                    Soru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoruTipi = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetonKontrolFormuSorulari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetonKontrolFormuSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BetonDemirTipi = table.Column<int>(type: "int", nullable: false),
                    ProductManifact2IdS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductManifact2Id = table.Column<int>(type: "int", nullable: false),
                    ManifactDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastControlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GermePersonId = table.Column<int>(type: "int", nullable: true),
                    UretimPersonId = table.Column<int>(type: "int", nullable: true),
                    ControlPersonId = table.Column<int>(type: "int", nullable: true),
                    LastControlPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetonKontrolFormuSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuSub_Personals_ControlPersonId",
                        column: x => x.ControlPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuSub_Personals_GermePersonId",
                        column: x => x.GermePersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuSub_Personals_LastControlPersonId",
                        column: x => x.LastControlPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuSub_Personals_UretimPersonId",
                        column: x => x.UretimPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BetonKontrolFormuSub_ProductManifacts2_ProductManifact2Id",
                        column: x => x.ProductManifact2Id,
                        principalTable: "ProductManifacts2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuCevaplari_QuestionId",
                table: "BetonKontrolFormuCevaplari",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuSub_ControlPersonId",
                table: "BetonKontrolFormuSub",
                column: "ControlPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuSub_GermePersonId",
                table: "BetonKontrolFormuSub",
                column: "GermePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuSub_LastControlPersonId",
                table: "BetonKontrolFormuSub",
                column: "LastControlPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuSub_ProductManifact2Id",
                table: "BetonKontrolFormuSub",
                column: "ProductManifact2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BetonKontrolFormuSub_UretimPersonId",
                table: "BetonKontrolFormuSub",
                column: "UretimPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetonKontrolFormuCevaplari");

            migrationBuilder.DropTable(
                name: "BetonKontrolFormuSorulari");

            migrationBuilder.DropTable(
                name: "BetonKontrolFormuSub");
        }
    }
}
