using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class owcbhabge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybills2_OutWaybillChanges_OutWaybillChangeId",
                table: "OutWaybills2");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybills2_OutWaybillChangeId",
                table: "OutWaybills2");

            migrationBuilder.DropColumn(
                name: "OutWaybillChangeId",
                table: "OutWaybills2");

            migrationBuilder.AddColumn<int>(
                name: "OutWaybill2Id",
                table: "OutWaybillChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybillChanges_OutWaybill2Id",
                table: "OutWaybillChanges",
                column: "OutWaybill2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybillChanges_OutWaybills2_OutWaybill2Id",
                table: "OutWaybillChanges",
                column: "OutWaybill2Id",
                principalTable: "OutWaybills2",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybillChanges_OutWaybills2_OutWaybill2Id",
                table: "OutWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybillChanges_OutWaybill2Id",
                table: "OutWaybillChanges");

            migrationBuilder.DropColumn(
                name: "OutWaybill2Id",
                table: "OutWaybillChanges");

            migrationBuilder.AddColumn<int>(
                name: "OutWaybillChangeId",
                table: "OutWaybills2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybills2_OutWaybillChangeId",
                table: "OutWaybills2",
                column: "OutWaybillChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybills2_OutWaybillChanges_OutWaybillChangeId",
                table: "OutWaybills2",
                column: "OutWaybillChangeId",
                principalTable: "OutWaybillChanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
