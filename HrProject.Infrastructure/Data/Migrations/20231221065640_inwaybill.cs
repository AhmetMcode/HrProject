using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class inwaybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InWaybills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariKartId = table.Column<int>(type: "int", nullable: false),
                    EntryInvoiceAdressId = table.Column<int>(type: "int", nullable: false),
                    EntryPostaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDistrictId = table.Column<int>(type: "int", nullable: false),
                    EntryCityId = table.Column<int>(type: "int", nullable: false),
                    ExitInvoiceAdressId = table.Column<int>(type: "int", nullable: false),
                    ExitPostaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDistrictId = table.Column<int>(type: "int", nullable: false),
                    ExitCityId = table.Column<int>(type: "int", nullable: false),
                    ShippingMethod = table.Column<int>(type: "int", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaybillNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PersonelCars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelNameDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasiyiciCars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasiyiciDriver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TasiyiciTC = table.Column<int>(type: "int", nullable: true),
                    KargoCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KargoTaxNumber = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InWaybills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InWaybills_CariKarts_CariKartId",
                        column: x => x.CariKartId,
                        principalTable: "CariKarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Citys_EntryCityId",
                        column: x => x.EntryCityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Citys_ExitCityId",
                        column: x => x.ExitCityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Districts_EntryDistrictId",
                        column: x => x.EntryDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Districts_ExitDistrictId",
                        column: x => x.ExitDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_InvoiceAdress_EntryInvoiceAdressId",
                        column: x => x.EntryInvoiceAdressId,
                        principalTable: "InvoiceAdress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_InvoiceAdress_ExitInvoiceAdressId",
                        column: x => x.ExitInvoiceAdressId,
                        principalTable: "InvoiceAdress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InWaybills_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_CariKartId",
                table: "InWaybills",
                column: "CariKartId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_EntryCityId",
                table: "InWaybills",
                column: "EntryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_EntryDistrictId",
                table: "InWaybills",
                column: "EntryDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_EntryInvoiceAdressId",
                table: "InWaybills",
                column: "EntryInvoiceAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_ExitCityId",
                table: "InWaybills",
                column: "ExitCityId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_ExitDistrictId",
                table: "InWaybills",
                column: "ExitDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_ExitInvoiceAdressId",
                table: "InWaybills",
                column: "ExitInvoiceAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_StockId",
                table: "InWaybills",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_UnitId",
                table: "InWaybills",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InWaybills");
        }
    }
}
