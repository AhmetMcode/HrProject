using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addinwaybill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InWaybills_InvoiceAdress_EntryInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_InWaybills_InvoiceAdress_ExitInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_InWaybills_Stocks_StockId",
                table: "InWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_InWaybills_Units_UnitId",
                table: "InWaybills");

            migrationBuilder.DropIndex(
                name: "IX_InWaybills_EntryInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropIndex(
                name: "IX_InWaybills_ExitInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropIndex(
                name: "IX_InWaybills_StockId",
                table: "InWaybills");

            migrationBuilder.DropIndex(
                name: "IX_InWaybills_UnitId",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "EntryInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "ExitInvoiceAdressId",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "InWaybills");

            migrationBuilder.AddColumn<int>(
                name: "InWaybillId",
                table: "OutWaybillChanges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryInvoiceAdress",
                table: "InWaybills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExitInvoiceAdress",
                table: "InWaybills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybillChanges_InWaybillId",
                table: "OutWaybillChanges",
                column: "InWaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybillChanges_InWaybills_InWaybillId",
                table: "OutWaybillChanges",
                column: "InWaybillId",
                principalTable: "InWaybills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybillChanges_InWaybills_InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybillChanges_InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.DropColumn(
                name: "InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.DropColumn(
                name: "EntryInvoiceAdress",
                table: "InWaybills");

            migrationBuilder.DropColumn(
                name: "ExitInvoiceAdress",
                table: "InWaybills");

            migrationBuilder.AddColumn<int>(
                name: "EntryInvoiceAdressId",
                table: "InWaybills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExitInvoiceAdressId",
                table: "InWaybills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "InWaybills",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "InWaybills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "InWaybills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InWaybills_EntryInvoiceAdressId",
                table: "InWaybills",
                column: "EntryInvoiceAdressId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybills_InvoiceAdress_EntryInvoiceAdressId",
                table: "InWaybills",
                column: "EntryInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybills_InvoiceAdress_ExitInvoiceAdressId",
                table: "InWaybills",
                column: "ExitInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybills_Stocks_StockId",
                table: "InWaybills",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybills_Units_UnitId",
                table: "InWaybills",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
