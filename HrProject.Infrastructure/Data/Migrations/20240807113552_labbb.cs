using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class labbb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabaratuarSonuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPlanDailyPlannedId = table.Column<int>(type: "int", nullable: false),
                    BirinciSonuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BirinciSonucAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IkınciSonuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IkınciSonucAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YediGunSonuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YediGunSonucAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YirmiBirGunSonuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YirmiBirGunSonucAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YirmiSekizGunSonuc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YirmiSekizGunSonucAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SokumOnay = table.Column<bool>(type: "bit", nullable: false),
                    SokumOnayAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabaratuarSonuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabaratuarSonuc_ProductPlanDailyPlanned_ProductPlanDailyPlannedId",
                        column: x => x.ProductPlanDailyPlannedId,
                        principalTable: "ProductPlanDailyPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabaratuarSonuc_ProductPlanDailyPlannedId",
                table: "LabaratuarSonuc",
                column: "ProductPlanDailyPlannedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabaratuarSonuc");
        }
    }
}
