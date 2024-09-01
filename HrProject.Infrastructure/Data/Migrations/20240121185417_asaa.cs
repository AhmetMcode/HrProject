using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class asaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferCalculateId",
                table: "ProductPlanSubPlanned",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PmCalculateId",
                table: "ProductPlanSubPlanned",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quant",
                table: "ProductPlanSubPlanned",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanSubPlanned_OfferCalculateId",
                table: "ProductPlanSubPlanned",
                column: "OfferCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanSubPlanned_PmCalculateId",
                table: "ProductPlanSubPlanned",
                column: "PmCalculateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPlanSubPlanned_OfferCalculates_OfferCalculateId",
                table: "ProductPlanSubPlanned",
                column: "OfferCalculateId",
                principalTable: "OfferCalculates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPlanSubPlanned_PmCalculates_PmCalculateId",
                table: "ProductPlanSubPlanned",
                column: "PmCalculateId",
                principalTable: "PmCalculates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPlanSubPlanned_OfferCalculates_OfferCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPlanSubPlanned_PmCalculates_PmCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropIndex(
                name: "IX_ProductPlanSubPlanned_OfferCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropIndex(
                name: "IX_ProductPlanSubPlanned_PmCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropColumn(
                name: "OfferCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropColumn(
                name: "PmCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropColumn(
                name: "Quant",
                table: "ProductPlanSubPlanned");
        }
    }
}
