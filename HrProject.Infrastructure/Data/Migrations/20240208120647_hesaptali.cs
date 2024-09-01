using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class hesaptali : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HesapTalis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Receivable = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HesapMuavinId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapTalis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HesapTalis_HesapMuavins_HesapMuavinId",
                        column: x => x.HesapMuavinId,
                        principalTable: "HesapMuavins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HesapTalis_HesapMuavinId",
                table: "HesapTalis",
                column: "HesapMuavinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HesapTalis");
        }
    }
}
