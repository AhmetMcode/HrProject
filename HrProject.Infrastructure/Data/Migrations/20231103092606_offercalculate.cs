using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offercalculate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferCalculates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ElementCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementName = table.Column<int>(type: "int", nullable: false),
                    ConcreteClassId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    GrossConcrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetConcrete = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IronKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WickerIronKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ANKRAJ = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IronPlusWicker = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossConcreteTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetConcreteTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IronKgTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WickerIronKgTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ANKRAJTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCalculates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCalculates_ConcreteClass_ConcreteClassId",
                        column: x => x.ConcreteClassId,
                        principalTable: "ConcreteClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferCalculates_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferCalculates_ConcreteClassId",
                table: "OfferCalculates",
                column: "ConcreteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCalculates_OfferId",
                table: "OfferCalculates",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferCalculates");
        }
    }
}
