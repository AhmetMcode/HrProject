using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybillChanges_InWaybills_InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybillChanges_InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.DropColumn(
                name: "InWaybillId",
                table: "OutWaybillChanges");

            migrationBuilder.AddColumn<int>(
                name: "InWaybillId",
                table: "InWaybillChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InWaybillChanges_InWaybillId",
                table: "InWaybillChanges",
                column: "InWaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybillChanges_InWaybills_InWaybillId",
                table: "InWaybillChanges",
                column: "InWaybillId",
                principalTable: "InWaybills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InWaybillChanges_InWaybills_InWaybillId",
                table: "InWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_InWaybillChanges_InWaybillId",
                table: "InWaybillChanges");

            migrationBuilder.DropColumn(
                name: "InWaybillId",
                table: "InWaybillChanges");

            migrationBuilder.AddColumn<int>(
                name: "InWaybillId",
                table: "OutWaybillChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybillChanges_InWaybillId",
                table: "OutWaybillChanges",
                column: "InWaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybillChanges_InWaybills_InWaybillId",
                table: "OutWaybillChanges",
                column: "InWaybillId",
                principalTable: "InWaybills",
                principalColumn: "Id");
        }
    }
}
