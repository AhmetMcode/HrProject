using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    public partial class ISGTablesAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ISGSafetyIssueCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISGSafetyIssueCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ISGSafetyIssueSubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskLevel = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISGSafetyIssueSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISGSafetyIssueSubCategory_ISGSafetyIssueCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ISGSafetyIssueCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ISGSafetyIssue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISGSafetyIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISGSafetyIssue_AspNetUsers_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ISGSafetyIssue_ISGSafetyIssueCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ISGSafetyIssueCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ISGSafetyIssue_ISGSafetyIssueSubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "ISGSafetyIssueSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ISGSafetyIssueImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SafetyIssueId = table.Column<int>(type: "int", nullable: false),
                    ISGSafetyIssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISGSafetyIssueImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ISGSafetyIssueImages_ISGSafetyIssue_ISGSafetyIssueId",
                        column: x => x.ISGSafetyIssueId,
                        principalTable: "ISGSafetyIssue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssue_CategoryId",
                table: "ISGSafetyIssue",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssue_ReportedById",
                table: "ISGSafetyIssue",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssue_SubCategoryId",
                table: "ISGSafetyIssue",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssueImages_ISGSafetyIssueId",
                table: "ISGSafetyIssueImages",
                column: "ISGSafetyIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ISGSafetyIssueSubCategory_CategoryId",
                table: "ISGSafetyIssueSubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ISGSafetyIssueImages");

            migrationBuilder.DropTable(
                name: "ISGSafetyIssue");

            migrationBuilder.DropTable(
                name: "ISGSafetyIssueSubCategory");

            migrationBuilder.DropTable(
                name: "ISGSafetyIssueCategory");
        }
    }
}
