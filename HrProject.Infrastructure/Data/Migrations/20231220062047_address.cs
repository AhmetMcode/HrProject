using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntryCityId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntryDistrictId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntryPostaCode",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExitCityId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExitDistrictId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExitPostaCode",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_EntryCityId",
                table: "OutWaybills2",
                column: "EntryCityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_EntryDistrictId",
                table: "OutWaybills2",
                column: "EntryDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_ExitCityId",
                table: "OutWaybills2",
                column: "ExitCityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_ExitDistrictId",
                table: "OutWaybills2",
                column: "ExitDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Citys_EntryCityId",
                table: "OutWaybills2",
                column: "EntryCityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Citys_ExitCityId",
                table: "OutWaybills2",
                column: "ExitCityId",
                principalTable: "Citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Districts_EntryDistrictId",
                table: "OutWaybills2",
                column: "EntryDistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Districts_ExitDistrictId",
                table: "OutWaybills2",
                column: "ExitDistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Citys_EntryCityId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Citys_ExitCityId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Districts_EntryDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Districts_ExitDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_EntryCityId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_EntryDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_ExitCityId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_ExitDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "EntryCityId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "EntryDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "EntryPostaCode",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "ExitCityId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "ExitDistrictId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "ExitPostaCode",
                table: "OutWaybills2");
        }
    }
}
