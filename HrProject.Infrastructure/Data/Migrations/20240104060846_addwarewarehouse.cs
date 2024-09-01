using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addwarewarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "OutWaybillChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "InWaybillChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutWaybillChanges_WareHouseId",
                table: "OutWaybillChanges",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InWaybillChanges_WareHouseId",
                table: "InWaybillChanges",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_InWaybillChanges_WareHouses_WareHouseId",
                table: "InWaybillChanges",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutWaybillChanges_WareHouses_WareHouseId",
                table: "OutWaybillChanges",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InWaybillChanges_WareHouses_WareHouseId",
                table: "InWaybillChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_OutWaybillChanges_WareHouses_WareHouseId",
                table: "OutWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_OutWaybillChanges_WareHouseId",
                table: "OutWaybillChanges");

            migrationBuilder.DropIndex(
                name: "IX_InWaybillChanges_WareHouseId",
                table: "InWaybillChanges");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "OutWaybillChanges");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "InWaybillChanges");
        }
    }
}
