using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class offerTerminSs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferTerminSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnsWer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTerminSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferTerminSub_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferTerminDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferTerminSubId = table.Column<int>(type: "int", nullable: false),
                    ProjectElementId = table.Column<int>(type: "int", nullable: false),
                    QuanTity = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTerminDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferTerminDetail_OfferTerminSub_OfferTerminSubId",
                        column: x => x.OfferTerminSubId,
                        principalTable: "OfferTerminSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferTerminDetail_ProjectElements_ProjectElementId",
                        column: x => x.ProjectElementId,
                        principalTable: "ProjectElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferTerminDetail_OfferTerminSubId",
                table: "OfferTerminDetail",
                column: "OfferTerminSubId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferTerminDetail_ProjectElementId",
                table: "OfferTerminDetail",
                column: "ProjectElementId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferTerminSub_OfferId",
                table: "OfferTerminSub",
                column: "OfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferTerminDetail");

            migrationBuilder.DropTable(
                name: "OfferTerminSub");
        }
    }
}
