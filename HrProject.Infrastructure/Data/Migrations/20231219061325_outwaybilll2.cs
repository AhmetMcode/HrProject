using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class outwaybilll2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills_CariKarts_CariKartId",
                table: "OutWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills_Stocks_StockId",
                table: "OutWaybills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutWaybills",
                table: "OutWaybills");

            migrationBuilder.RenameTable(
                name: "OutWaybills",
                newName: "OutWaybills2");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills_StockId",
                table: "OutWaybills2",
                newName: "IX_OutWaybills2_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills_ExitInvoiceAdressId",
                table: "OutWaybills2",
                newName: "IX_OutWaybills2_ExitInvoiceAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills_EntryInvoiceAdressId",
                table: "OutWaybills2",
                newName: "IX_OutWaybills2_EntryInvoiceAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills_CariKartId",
                table: "OutWaybills2",
                newName: "IX_OutWaybills2_CariKartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutWaybills2",
                table: "OutWaybills2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_CariKarts_CariKartId",
                table: "OutWaybills2",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills2",
                column: "EntryInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills2",
                column: "ExitInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Stocks_StockId",
                table: "OutWaybills2",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_CariKarts_CariKartId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Stocks_StockId",
                table: "OutWaybills2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutWaybills2",
                table: "OutWaybills2");

            migrationBuilder.RenameTable(
                name: "OutWaybills2",
                newName: "OutWaybills");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills2_StockId",
                table: "OutWaybills",
                newName: "IX_OutWaybills_StockId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills2_ExitInvoiceAdressId",
                table: "OutWaybills",
                newName: "IX_OutWaybills_ExitInvoiceAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills2_EntryInvoiceAdressId",
                table: "OutWaybills",
                newName: "IX_OutWaybills_EntryInvoiceAdressId");

            migrationBuilder.RenameIndex(
                name: "IX_OutWaybills2_CariKartId",
                table: "OutWaybills",
                newName: "IX_OutWaybills_CariKartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutWaybills",
                table: "OutWaybills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills_CariKarts_CariKartId",
                table: "OutWaybills",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills",
                column: "EntryInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills",
                column: "ExitInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills_Stocks_StockId",
                table: "OutWaybills",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
