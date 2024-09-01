using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class requesconcrete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcreteRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantRequest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantAction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConcreteClassId = table.Column<int>(type: "int", nullable: false),
                    RequestUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteRequests_AspNetUsers_ActionUserId",
                        column: x => x.ActionUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConcreteRequests_AspNetUsers_RequestUserId",
                        column: x => x.RequestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcreteRequests_ConcreteClass_ConcreteClassId",
                        column: x => x.ConcreteClassId,
                        principalTable: "ConcreteClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteRequests_ActionUserId",
                table: "ConcreteRequests",
                column: "ActionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteRequests_ConcreteClassId",
                table: "ConcreteRequests",
                column: "ConcreteClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteRequests_RequestUserId",
                table: "ConcreteRequests",
                column: "RequestUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcreteRequests");
        }
    }
}
