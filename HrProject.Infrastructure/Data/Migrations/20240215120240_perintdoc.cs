using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class perintdoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonelInterDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonelAuthorityId = table.Column<int>(type: "int", nullable: false),
                    SigningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SigningDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelInterDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelInterDocs_Personals_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelInterDocs_PersonelAuthorities_PersonelAuthorityId",
                        column: x => x.PersonelAuthorityId,
                        principalTable: "PersonelAuthorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterDocs_PersonelAuthorityId",
                table: "PersonelInterDocs",
                column: "PersonelAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterDocs_PersonId",
                table: "PersonelInterDocs",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelInterDocs");
        }
    }
}
