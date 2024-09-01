using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class hesapgruplari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HesapGruplaris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Receivable = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HesapSiniflariId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapGruplaris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HesapGruplaris_HesapSiniflaris_HesapSiniflariId",
                        column: x => x.HesapSiniflariId,
                        principalTable: "HesapSiniflaris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HesapGruplaris_HesapSiniflariId",
                table: "HesapGruplaris",
                column: "HesapSiniflariId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesapGruplaris");
        }
    }
}
