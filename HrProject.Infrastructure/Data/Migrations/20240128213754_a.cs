using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ConcreteProductionPlaceId",
                table: "ProductManifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionPlaceId",
                table: "ProductManifacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConcreteProductionPlaceId",
                table: "ProductManifacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ConcreteProductionPlaceId",
                table: "ProductManifacts",
                column: "ConcreteProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts",
                column: "ProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ConcreteProductionPlaceId",
                table: "ProductManifacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionPlaceId",
                table: "ProductManifacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConcreteProductionPlaceId",
                table: "ProductManifacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ConcreteProductionPlaceId",
                table: "ProductManifacts",
                column: "ConcreteProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts_ProductionPlaces_ProductionPlaceId",
                table: "ProductManifacts",
                column: "ProductionPlaceId",
                principalTable: "ProductionPlaces",
                principalColumn: "Id");
        }
    }
}
