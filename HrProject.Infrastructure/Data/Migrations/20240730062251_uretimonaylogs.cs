using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uretimonaylogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UretimOnay",
                table: "ProjectModuleSub",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UretimOnayBelge",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UretimOnayBelgeAd",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UretimOnayBelgeUzanti",
                table: "ProjectModuleSub",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UretimOnayLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderimZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UretimOnay = table.Column<bool>(type: "bit", nullable: false),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UretimOnayLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UretimOnayLog_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UretimOnayLog_ProjectModuleSubId",
                table: "UretimOnayLog",
                column: "ProjectModuleSubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UretimOnayLog");

            migrationBuilder.DropColumn(
                name: "UretimOnay",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "UretimOnayBelge",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "UretimOnayBelgeAd",
                table: "ProjectModuleSub");

            migrationBuilder.DropColumn(
                name: "UretimOnayBelgeUzanti",
                table: "ProjectModuleSub");
        }
    }
}
