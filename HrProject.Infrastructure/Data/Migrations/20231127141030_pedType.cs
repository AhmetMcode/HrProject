using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pedType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectElementTypeId",
                table: "OfferCalculates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectElementType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectElementId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectElementType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectElementType_ProjectElements_ProjectElementId",
                        column: x => x.ProjectElementId,
                        principalTable: "ProjectElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferCalculates_ProjectElementTypeId",
                table: "OfferCalculates",
                column: "ProjectElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectElementType_ProjectElementId",
                table: "ProjectElementType",
                column: "ProjectElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCalculates_ProjectElementType_ProjectElementTypeId",
                table: "OfferCalculates",
                column: "ProjectElementTypeId",
                principalTable: "ProjectElementType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCalculates_ProjectElementType_ProjectElementTypeId",
                table: "OfferCalculates");

            migrationBuilder.DropTable(
                name: "ProjectElementType");

            migrationBuilder.DropIndex(
                name: "IX_OfferCalculates_ProjectElementTypeId",
                table: "OfferCalculates");

            migrationBuilder.DropColumn(
                name: "ProjectElementTypeId",
                table: "OfferCalculates");
        }
    }
}
