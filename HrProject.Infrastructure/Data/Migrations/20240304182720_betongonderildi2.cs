using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class betongonderildi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifactDetails_ConcreteRequests_ConcreteRequestId",
                table: "ProductManifactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductManifactDetails_ConcreteRequestId",
                table: "ProductManifactDetails");

            migrationBuilder.DropColumn(
                name: "ConcreteRequestId",
                table: "ProductManifactDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "UretimBitisZamani",
                table: "ProductManifacts2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UretimBitisZamani",
                table: "ProductManifacts2");

            migrationBuilder.AddColumn<int>(
                name: "ConcreteRequestId",
                table: "ProductManifactDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifactDetails_ConcreteRequestId",
                table: "ProductManifactDetails",
                column: "ConcreteRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifactDetails_ConcreteRequests_ConcreteRequestId",
                table: "ProductManifactDetails",
                column: "ConcreteRequestId",
                principalTable: "ConcreteRequests",
                principalColumn: "Id");
        }
    }
}
