using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class prpmodesube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SendProject",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProjectModuleSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModuleSub", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModuleStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    ProjectProcessStage = table.Column<int>(type: "int", nullable: false),
                    RecipentUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ResponsibleUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModuleStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModuleStatus_AspNetUsers_RecipentUserId",
                        column: x => x.RecipentUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectModuleStatus_AspNetUsers_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectModuleStatus_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModuleStatus_ProjectModuleSubId",
                table: "ProjectModuleStatus",
                column: "ProjectModuleSubId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModuleStatus_RecipentUserId",
                table: "ProjectModuleStatus",
                column: "RecipentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModuleStatus_ResponsibleUserId",
                table: "ProjectModuleStatus",
                column: "ResponsibleUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectModuleStatus");

            migrationBuilder.DropTable(
                name: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "SendProject",
                table: "Offers");
        }
    }
}
