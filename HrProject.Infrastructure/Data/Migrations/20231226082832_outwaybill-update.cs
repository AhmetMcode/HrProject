using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class outwaybillupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
