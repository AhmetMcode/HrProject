using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFaturaEkleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_CariKarts_CariKartId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "CariTitle",
                table: "Invoices",
                newName: "CariTel");

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Account2Id",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CariFax",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CariTCVKN",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices",
                column: "Account2Id",
                principalTable: "Accounts2",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_CariKarts_CariKartId",
                table: "Invoices",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_CariKarts_CariKartId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CariFax",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CariTCVKN",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "CariTel",
                table: "Invoices",
                newName: "CariTitle");

            migrationBuilder.AlterColumn<int>(
                name: "CariKartId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Account2Id",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Accounts2_Account2Id",
                table: "Invoices",
                column: "Account2Id",
                principalTable: "Accounts2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_CariKarts_CariKartId",
                table: "Invoices",
                column: "CariKartId",
                principalTable: "CariKarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
