using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class prpmodesube2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "ProjectModuleSub",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModuleSub_OfferId",
                table: "ProjectModuleSub",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModuleSub_Offers_OfferId",
                table: "ProjectModuleSub",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModuleSub_Offers_OfferId",
                table: "ProjectModuleSub");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModuleSub_OfferId",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "ProjectModuleSub");
        }
    }
}
