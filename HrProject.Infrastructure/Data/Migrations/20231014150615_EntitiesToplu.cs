using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesToplu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariKartId",
                table: "InvoiceAdress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CariBanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariBanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CariRisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariKartId = table.Column<int>(type: "int", nullable: false),
                    RiskLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskControl = table.Column<int>(type: "int", nullable: false),
                    LimitActionAll = table.Column<int>(type: "int", nullable: false),
                    LimitActionDelivery = table.Column<int>(type: "int", nullable: false),
                    LimitActionOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CariRisks_CariKarts_CariKartId",
                        column: x => x.CariKartId,
                        principalTable: "CariKarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress",
                column: "CariKartId");

            migrationBuilder.CreateIndex(
                name: "IX_CariRisks_CariKartId",
                table: "CariRisks",
                column: "CariKartId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceAdress_CariKarts_CariKartId",
                table: "InvoiceAdress",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceAdress_CariKarts_CariKartId",
                table: "InvoiceAdress");

            migrationBuilder.DropTable(
                name: "CariBanks");

            migrationBuilder.DropTable(
                name: "CariRisks");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress");

            migrationBuilder.DropColumn(
                name: "CariKartId",
                table: "InvoiceAdress");
        }
    }
}
