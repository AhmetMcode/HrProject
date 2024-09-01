using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class OtherCariRiskMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtherCariRisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariKartId = table.Column<int>(type: "int", nullable: false),
                    OwnCheckAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnCheckAction = table.Column<int>(type: "int", nullable: false),
                    CustomerCheckAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerCheckAction = table.Column<int>(type: "int", nullable: false),
                    DeliveryNoteAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryNoteAction = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCariRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherCariRisks_CariKarts_CariKartId",
                        column: x => x.CariKartId,
                        principalTable: "CariKarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherCariRisks_CariKartId",
                table: "OtherCariRisks",
                column: "CariKartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherCariRisks");
        }
    }
}
