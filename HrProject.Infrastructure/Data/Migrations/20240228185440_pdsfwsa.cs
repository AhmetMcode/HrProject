using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pdsfwsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStepNotifs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserRoleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityUserRoleUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityUserRoleRoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductionStepId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<bool>(type: "bit", nullable: false),
                    Mobil = table.Column<bool>(type: "bit", nullable: false),
                    Web = table.Column<bool>(type: "bit", nullable: false),
                    Sms = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStepNotifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStepNotifs_AspNetUserRoles_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                        columns: x => new { x.IdentityUserRoleUserId, x.IdentityUserRoleRoleId },
                        principalTable: "AspNetUserRoles",
                        principalColumns: new[] { "UserId", "RoleId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStepNotifs_ProductionStep_ProductionStepId",
                        column: x => x.ProductionStepId,
                        principalTable: "ProductionStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStepNotifs_IdentityUserRoleUserId_IdentityUserRoleRoleId",
                table: "ProductStepNotifs",
                columns: new[] { "IdentityUserRoleUserId", "IdentityUserRoleRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStepNotifs_ProductionStepId",
                table: "ProductStepNotifs",
                column: "ProductionStepId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStepNotifs");
        }
    }
}
