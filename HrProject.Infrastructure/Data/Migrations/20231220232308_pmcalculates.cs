using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class pmcalculates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmCalculates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ElementCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectElementId = table.Column<int>(type: "int", nullable: false),
                    ProjectElementTypeId = table.Column<int>(type: "int", nullable: true),
                    ElementName = table.Column<int>(type: "int", nullable: false),
                    ConcreteClassId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    GrossConcrete = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    NetConcrete = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    IronKg = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    IronKgTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    IronPlusWicker = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    GrossConcreteTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    NetConcreteTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    RopeIronKg = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    RopeIronKgTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    WickerIronKg = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    WickerIronKgTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ANKRAJ = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ANKRAJTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ConfirmBy = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmCalculates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmCalculates_ConcreteClass_ConcreteClassId",
                        column: x => x.ConcreteClassId,
                        principalTable: "ConcreteClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmCalculates_ProjectElementTypes_ProjectElementTypeId",
                        column: x => x.ProjectElementTypeId,
                        principalTable: "ProjectElementTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PmCalculates_ProjectElements_ProjectElementId",
                        column: x => x.ProjectElementId,
                        principalTable: "ProjectElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmCalculates_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmCalculates_ConcreteClassId",
                table: "PmCalculates",
                column: "ConcreteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PmCalculates_ProjectElementId",
                table: "PmCalculates",
                column: "ProjectElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PmCalculates_ProjectElementTypeId",
                table: "PmCalculates",
                column: "ProjectElementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PmCalculates_ProjectModuleSubId",
                table: "PmCalculates",
                column: "ProjectModuleSubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmCalculates");
        }
    }
}
