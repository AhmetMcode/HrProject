using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class retfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers");

            migrationBuilder.AlterColumn<int>(
                name: "SalesBaseOfferId",
                table: "SalesDetailOffers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetailOffers_SalesBaseOffers_SalesBaseOfferId",
                table: "SalesDetailOffers",
                column: "SalesBaseOfferId",
                principalTable: "SalesBaseOffers",
                principalColumn: "Id");
        }
    }
}
