using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uretildi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConcreteRequestId",
                table: "ProductManifacts2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductManifacts2_ConcreteRequestId",
                table: "ProductManifacts2",
                column: "ConcreteRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductManifacts2_ConcreteRequests_ConcreteRequestId",
                table: "ProductManifacts2",
                column: "ConcreteRequestId",
                principalTable: "ConcreteRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductManifacts2_ConcreteRequests_ConcreteRequestId",
                table: "ProductManifacts2");

            migrationBuilder.DropIndex(
                name: "IX_ProductManifacts2_ConcreteRequestId",
                table: "ProductManifacts2");

            migrationBuilder.DropColumn(
                name: "ConcreteRequestId",
                table: "ProductManifacts2");
        }
    }
}
