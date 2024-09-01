using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMailProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress");

            migrationBuilder.DropColumn(
                name: "DefaultAddress",
                table: "CariKarts");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultAddress",
                table: "InvoiceAdress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "InvoiceAdress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress",
                column: "CariKartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress");

            migrationBuilder.DropColumn(
                name: "DefaultAddress",
                table: "InvoiceAdress");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "InvoiceAdress");

            migrationBuilder.AddColumn<bool>(
                name: "DefaultAddress",
                table: "CariKarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceAdress_CariKartId",
                table: "InvoiceAdress",
                column: "CariKartId",
                unique: true);
        }
    }
}
