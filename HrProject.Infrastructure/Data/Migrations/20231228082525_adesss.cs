using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class adesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_EntryInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_ExitInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "EntryInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "ExitInvoiceAdressId",
                table: "OutWaybills2");

            migrationBuilder.AddColumn<string>(
                name: "EntryInvoiceAdress",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExitInvoiceAdress",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryInvoiceAdress",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "ExitInvoiceAdress",
                table: "OutWaybills2");

            migrationBuilder.AddColumn<int>(
                name: "EntryInvoiceAdressId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExitInvoiceAdressId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_EntryInvoiceAdressId",
                table: "OutWaybills2",
                column: "EntryInvoiceAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_ExitInvoiceAdressId",
                table: "OutWaybills2",
                column: "ExitInvoiceAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_EntryInvoiceAdressId",
                table: "OutWaybills2",
                column: "EntryInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_InvoiceAdress_ExitInvoiceAdressId",
                table: "OutWaybills2",
                column: "ExitInvoiceAdressId",
                principalTable: "InvoiceAdress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
