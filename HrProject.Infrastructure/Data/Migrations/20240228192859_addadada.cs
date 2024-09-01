using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class addadada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStepNotifs_AspNetUserRoles_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.DropIndex(
                name: "IX_ProductStepNotifs_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.DropColumn(
                name: "IdentityUserRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.DropColumn(
                name: "IdentityUserRoleRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.RenameColumn(
                name: "IdentityUserRoleUserId",
                table: "ProductStepNotifs",
                newName: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStepNotifs_IdentityRoleId",
                table: "ProductStepNotifs",
                column: "IdentityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStepNotifs_AspNetRoles_IdentityRoleId",
                table: "ProductStepNotifs",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStepNotifs_AspNetRoles_IdentityRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.DropIndex(
                name: "IX_ProductStepNotifs_IdentityRoleId",
                table: "ProductStepNotifs");

            migrationBuilder.RenameColumn(
                name: "IdentityRoleId",
                table: "ProductStepNotifs",
                newName: "IdentityUserRoleUserId");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserRoleId",
                table: "ProductStepNotifs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserRoleRoleId",
                table: "ProductStepNotifs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStepNotifs_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                table: "ProductStepNotifs",
                columns: new[] { "IdentityUserRoleUserId", "IdentityUserRoleRoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStepNotifs_AspNetUserRoles_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                table: "ProductStepNotifs",
                columns: new[] { "IdentityUserRoleUserId", "IdentityUserRoleRoleId" },
                principalTable: "AspNetUserRoles",
                principalColumns: new[] { "UserId", "RoleId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
