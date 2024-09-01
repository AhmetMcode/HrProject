using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditOffer3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_CariKarts_CariKartId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Citys_CityId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Districts_DistrictId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_CariKarts_CariKartId",
                table: "Offers",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Citys_CityId",
                table: "Offers",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Districts_DistrictId",
                table: "Offers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_CariKarts_CariKartId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Citys_CityId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Districts_DistrictId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_CariKarts_CariKartId",
                table: "Offers",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Citys_CityId",
                table: "Offers",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Districts_DistrictId",
                table: "Offers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
