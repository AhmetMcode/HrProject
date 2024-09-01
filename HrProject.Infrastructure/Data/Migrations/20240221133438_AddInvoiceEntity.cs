using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceScenarioTypeEnum = table.Column<int>(type: "int", nullable: false),
                    InvoiceTypeEnum = table.Column<int>(type: "int", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    InvoicePaymentMethodEnum = table.Column<int>(type: "int", nullable: false),
                    InvoicePaymentChannelEnum = table.Column<int>(type: "int", nullable: false),
                    CariKartId = table.Column<int>(type: "int", nullable: false),
                    Account2Id = table.Column<int>(type: "int", nullable: false),
                    ETTN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomizationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CariTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariTradeRegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariOfficialTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariTaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariTaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariVehicleNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariVehiclePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariPostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CariEMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    OrderDocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDocumentNo = table.Column<int>(type: "int", nullable: false),
                    OrderDocumentFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelayPenaltyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DelayPenaltyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DelayPenaltyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptZReportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptOKCNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalInvoiceBaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoiceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoiceInsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoiceNavlunAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoiceFOBAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoicemountWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoicemountWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoicemountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalInvoicemountPaidWriting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Accounts2_Account2Id",
                        column: x => x.Account2Id,
                        principalTable: "Accounts2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_CariKarts_CariKartId",
                        column: x => x.CariKartId,
                        principalTable: "CariKarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceAdditionalDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceAdditionalDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceAdditionalDocuments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceGoodsAcceptances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceGoodsAcceptances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceGoodsAcceptances_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSubWaybills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    OutWaybill2Id = table.Column<int>(type: "int", nullable: false),
                    OutWaybill2Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutWaybill2Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSubWaybills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSubWaybills_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceSubWaybills_OutWaybills2_OutWaybill2Id",
                        column: x => x.OutWaybill2Id,
                        principalTable: "OutWaybills2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceStocks_InvoiceId",
                table: "InvoiceStocks",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAdditionalDocuments_InvoiceId",
                table: "InvoiceAdditionalDocuments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceGoodsAcceptances_InvoiceId",
                table: "InvoiceGoodsAcceptances",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Account2Id",
                table: "Invoices",
                column: "Account2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CariKartId",
                table: "Invoices",
                column: "CariKartId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSubWaybills_InvoiceId",
                table: "InvoiceSubWaybills",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSubWaybills_OutWaybill2Id",
                table: "InvoiceSubWaybills",
                column: "OutWaybill2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceStocks_Invoices_InvoiceId",
                table: "InvoiceStocks",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceStocks_Invoices_InvoiceId",
                table: "InvoiceStocks");

            migrationBuilder.DropTable(
                name: "InvoiceAdditionalDocuments");

            migrationBuilder.DropTable(
                name: "InvoiceGoodsAcceptances");

            migrationBuilder.DropTable(
                name: "InvoiceSubWaybills");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceStocks_InvoiceId",
                table: "InvoiceStocks");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceStocks");
        }
    }
}
