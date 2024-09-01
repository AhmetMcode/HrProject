using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class adad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPlanSubPlanned_PmCalculates_PmCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropIndex(
                name: "IX_ProductPlanSubPlanned_PmCalculateId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.RenameColumn(
                name: "PmCalculateId",
                table: "ProductPlanSubPlanned",
                newName: "TerminType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductPlanSubPlanned",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PatternId",
                table: "ProductPlanSubPlanned",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductPlanDailyPlanned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPlanSubPlannedId = table.Column<int>(type: "int", nullable: false),
                    Actual = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPlanDailyPlanned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPlanDailyPlanned_ProductPlanSubPlanned_ProductPlanSubPlannedId",
                        column: x => x.ProductPlanSubPlannedId,
                        principalTable: "ProductPlanSubPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPlanProductPlanned",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPlanDailyPlannedId = table.Column<int>(type: "int", nullable: false),
                    Actual = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPlanProductPlanned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPlanProductPlanned_ProductPlanDailyPlanned_ProductPlanDailyPlannedId",
                        column: x => x.ProductPlanDailyPlannedId,
                        principalTable: "ProductPlanDailyPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanSubPlanned_PatternId",
                table: "ProductPlanSubPlanned",
                column: "PatternId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanDailyPlanned_ProductPlanSubPlannedId",
                table: "ProductPlanDailyPlanned",
                column: "ProductPlanSubPlannedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanProductPlanned_ProductPlanDailyPlannedId",
                table: "ProductPlanProductPlanned",
                column: "ProductPlanDailyPlannedId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPlanSubPlanned_Patterns_PatternId",
                table: "ProductPlanSubPlanned",
                column: "PatternId",
                principalTable: "Patterns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPlanSubPlanned_Patterns_PatternId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropTable(
                name: "ProductPlanProductPlanned");

            migrationBuilder.DropTable(
                name: "ProductPlanDailyPlanned");

            migrationBuilder.DropIndex(
                name: "IX_ProductPlanSubPlanned_PatternId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductPlanSubPlanned");

            migrationBuilder.DropColumn(
                name: "PatternId",
                table: "ProductPlanSubPlanned");

            migrationBuilder.RenameColumn(
                name: "TerminType",
                table: "ProductPlanSubPlanned",
                newName: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPlanSubPlanned_PmCalculateId",
                table: "ProductPlanSubPlanned",
                column: "PmCalculateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPlanSubPlanned_PmCalculates_PmCalculateId",
                table: "ProductPlanSubPlanned",
                column: "PmCalculateId",
                principalTable: "PmCalculates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
