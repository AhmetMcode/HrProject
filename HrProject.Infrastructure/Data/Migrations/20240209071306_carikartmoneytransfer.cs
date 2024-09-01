using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class carikartmoneytransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers");

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "MoneyTransfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DailyManifactReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    UretilenAdet = table.Column<int>(type: "int", nullable: false),
                    KalanAdet = table.Column<int>(type: "int", nullable: false),
                    UretilenMetrekup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamMetrekup = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyManifactReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyManifactReports_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManifactReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    BirimMaaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManifactReportStatus = table.Column<int>(type: "int", nullable: false),
                    SozlesmeMetraj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjeMetraj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Uretilen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kalan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UretilmisMaaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KalanMaaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamMaaliyet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifactReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifactReports_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyManifactReportDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyManifactReportId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyManifactReportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyManifactReportDetails_DailyManifactReports_DailyManifactReportId",
                        column: x => x.DailyManifactReportId,
                        principalTable: "DailyManifactReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyManifactReportDetails_DailyManifactReportId",
                table: "DailyManifactReportDetails",
                column: "DailyManifactReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyManifactReports_PmCalculateId",
                table: "DailyManifactReports",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifactReports_ProjectModuleSubId",
                table: "ManifactReports",
                column: "ProjectModuleSubId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers");

            migrationBuilder.DropTable(
                name: "DailyManifactReportDetails");

            migrationBuilder.DropTable(
                name: "ManifactReports");

            migrationBuilder.DropTable(
                name: "DailyManifactReports");

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "MoneyTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransfers_CariKarts_CariKartId",
                table: "MoneyTransfers",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
