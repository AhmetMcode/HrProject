using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class hasiriron : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HasirIrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferCalculateId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToronDiameterId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasirIrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasirIrons_OfferCalculates_OfferCalculateId",
                        column: x => x.OfferCalculateId,
                        principalTable: "OfferCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasirIrons_ToronDiameters_ToronDiameterId",
                        column: x => x.ToronDiameterId,
                        principalTable: "ToronDiameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HasirIrons_OfferCalculateId",
                table: "HasirIrons",
                column: "OfferCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_HasirIrons_ToronDiameterId",
                table: "HasirIrons",
                column: "ToronDiameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HasirIrons");
        }
    }
}
