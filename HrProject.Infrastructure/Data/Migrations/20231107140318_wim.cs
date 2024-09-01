using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class wim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WickerIronCalculate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferCalculateId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Similar = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SteelMeshTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WickerIronCalculate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WickerIronCalculate_OfferCalculates_OfferCalculateId",
                        column: x => x.OfferCalculateId,
                        principalTable: "OfferCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WickerIronCalculate_SteelMeshType_SteelMeshTypeId",
                        column: x => x.SteelMeshTypeId,
                        principalTable: "SteelMeshType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WickerIronCalculate_OfferCalculateId",
                table: "WickerIronCalculate",
                column: "OfferCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_WickerIronCalculate_SteelMeshTypeId",
                table: "WickerIronCalculate",
                column: "SteelMeshTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WickerIronCalculate");
        }
    }
}
