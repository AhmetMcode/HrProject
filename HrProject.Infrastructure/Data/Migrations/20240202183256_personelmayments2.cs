using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class personelmayments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonMounthPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalismasiGereken = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalisilanSaat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMesai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrutUcret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IkramiyePrimFazlaMesai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GelirVergisiIndirimi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SgkMatrahi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SgkKesintisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IssizlikSigortasi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BesKesintisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DigerKesintiler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VergiMatrahi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KumuleVergiMatrahi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GelirVergisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrtalamaGelirVergisiOrani = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DamgaVergisi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetUcret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMounthPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonMounthPayments_Personals_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonMounthPayments_PersonId",
                table: "PersonMounthPayments",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonMounthPayments");
        }
    }
}
