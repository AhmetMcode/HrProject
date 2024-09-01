using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ofereef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.AddColumn<decimal>(
                name: "GeneralTotal",
                table: "SalesOffers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GeneralVATTotal",
                table: "SalesOffers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "SalesOffers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesBaseOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SalesOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetailOffers_SalesOfferId",
                table: "SalesDetailOffers",
                column: "SalesOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers",
                column: "SalesBaseOfferId",
                principalTable: "SalesBaseOffers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesOffers_SalesOfferId",
                table: "SalesDetailOffers",
                column: "SalesOfferId",
                principalTable: "SalesOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesOffers_SalesOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropIndex(
                name: "IX_SalesDetailOffers_SalesOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.DropColumn(
                name: "GeneralTotal",
                table: "SalesOffers");

            migrationBuilder.DropColumn(
                name: "GeneralVATTotal",
                table: "SalesOffers");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SalesOffers");

            migrationBuilder.DropColumn(
                name: "SalesOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.AlterColumn<int>(
                name: "SalesBaseOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers",
                column: "SalesBaseOfferId",
                principalTable: "SalesBaseOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
