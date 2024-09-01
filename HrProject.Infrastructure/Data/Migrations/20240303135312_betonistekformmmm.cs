using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class betonistekformmmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
