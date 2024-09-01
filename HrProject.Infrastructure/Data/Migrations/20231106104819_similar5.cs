using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class similar5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementDetails_SteelMeshType_SteelMeshTypeId",
                table: "ProjectElementDetails");

            migrationBuilder.RenameColumn(
                name: "SteelMeshTypeId",
                table: "ProjectElementDetails",
                newName: "IronDiameterWeightId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementDetails_SteelMeshTypeId",
                table: "ProjectElementDetails",
                newName: "IX_ProjectElementDetails_IronDiameterWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementDetails_IronDiameterWeights_IronDiameterWeightId",
                table: "ProjectElementDetails",
                column: "IronDiameterWeightId",
                principalTable: "IronDiameterWeights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectElementDetails_IronDiameterWeights_IronDiameterWeightId",
                table: "ProjectElementDetails");

            migrationBuilder.RenameColumn(
                name: "IronDiameterWeightId",
                table: "ProjectElementDetails",
                newName: "SteelMeshTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectElementDetails_IronDiameterWeightId",
                table: "ProjectElementDetails",
                newName: "IX_ProjectElementDetails_SteelMeshTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectElementDetails_SteelMeshType_SteelMeshTypeId",
                table: "ProjectElementDetails",
                column: "SteelMeshTypeId",
                principalTable: "SteelMeshType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
