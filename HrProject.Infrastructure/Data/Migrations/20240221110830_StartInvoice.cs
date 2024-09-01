using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class StartInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceVATExemptionReasonEnum = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    SaleVatId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VATAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoodsOrServiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountIncludingVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceStocks_SaleVats_SaleVatId",
                        column: x => x.SaleVatId,
                        principalTable: "SaleVats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceStocks_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceStocks_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStockDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceStockId = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStockDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceStockDiscounts_InvoiceStocks_InvoiceStockId",
                        column: x => x.InvoiceStockId,
                        principalTable: "InvoiceStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStockTaxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceStockId = table.Column<int>(type: "int", nullable: false),
                    InvoiceTaxTypeEnum = table.Column<int>(type: "int", nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStockTaxs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceStockTaxs_InvoiceStocks_InvoiceStockId",
                        column: x => x.InvoiceStockId,
                        principalTable: "InvoiceStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStockDiscounts_InvoiceStockId",
                table: "InvoiceStockDiscounts",
                column: "InvoiceStockId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStocks_SaleVatId",
                table: "InvoiceStocks",
                column: "SaleVatId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStocks_StockId",
                table: "InvoiceStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStocks_UnitId",
                table: "InvoiceStocks",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStockTaxs_InvoiceStockId",
                table: "InvoiceStockTaxs",
                column: "InvoiceStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceStockDiscounts");

            migrationBuilder.DropTable(
                name: "InvoiceStockTaxs");

            migrationBuilder.DropTable(
                name: "InvoiceStocks");
        }
    }
}
