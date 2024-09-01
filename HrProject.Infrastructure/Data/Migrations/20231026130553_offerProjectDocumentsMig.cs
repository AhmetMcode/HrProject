using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerProjectDocumentsMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferProjectDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    Document1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferProjectDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferProjectDocuments_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferProjectDocuments_OfferId",
                table: "OfferProjectDocuments",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferProjectDocuments");
        }
    }
}
