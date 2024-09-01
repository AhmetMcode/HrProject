﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class uploadfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUploadLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadFolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadUserIdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploadLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileUploadLog_AspNetUsers_UploadUserIdId",
                        column: x => x.UploadUserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileUploadLog_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileUploadLog_ProjectModuleSubId",
                table: "FileUploadLog",
                column: "ProjectModuleSubId");

            migrationBuilder.CreateIndex(
                name: "IX_FileUploadLog_UploadUserIdId",
                table: "FileUploadLog",
                column: "UploadUserIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUploadLog");
        }
    }
}
