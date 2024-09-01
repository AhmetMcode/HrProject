using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class infocomp222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Resim",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FaturaHarf",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BinaNo",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaddeSokakBulvar",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EArsivHarf",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IlceSemtMahalle",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KapiNo",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sehir",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SirketAdresi",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicaretSicilNo",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ulke",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unvan",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VKN_TCKN",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VergiDairesi",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebAdres",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YetkiliAdSoyad",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BinaNo",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "CaddeSokakBulvar",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "EArsivHarf",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "IlceSemtMahalle",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "KapiNo",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "Sehir",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "SirketAdresi",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "TicaretSicilNo",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "Ulke",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "Unvan",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "VKN_TCKN",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "VergiDairesi",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "WebAdres",
                table: "InfoCompany");

            migrationBuilder.DropColumn(
                name: "YetkiliAdSoyad",
                table: "InfoCompany");

            migrationBuilder.AlterColumn<string>(
                name: "Resim",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaturaHarf",
                table: "InfoCompany",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
