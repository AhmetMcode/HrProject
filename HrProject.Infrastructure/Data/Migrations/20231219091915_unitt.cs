using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class unitt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deneme",
                table: "OutWaybills2");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OutWaybills2",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_UnitId",
                table: "OutWaybills2",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_Units_UnitId",
                table: "OutWaybills2",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_Units_UnitId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_UnitId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "OutWaybills2");

            migrationBuilder.AddColumn<string>(
                name: "Deneme",
                table: "OutWaybills2",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
