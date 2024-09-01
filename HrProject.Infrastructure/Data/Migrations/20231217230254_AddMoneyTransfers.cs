using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoneyTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accoıunt2Id = table.Column<int>(type: "int", nullable: false),
                    Account2Id = table.Column<int>(type: "int", nullable: false),
                    Bank2Id = table.Column<int>(type: "int", nullable: false),
                    MoneyTransfer = table.Column<int>(type: "int", nullable: false),
                    MoneyInOut = table.Column<bool>(type: "bit", nullable: false),
                    RelevantAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransfers_Accounts2_Account2Id",
                        column: x => x.Account2Id,
                        principalTable: "Accounts2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyTransfers_Banks2_Bank2Id",
                        column: x => x.Bank2Id,
                        principalTable: "Banks2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_Account2Id",
                table: "MoneyTransfers",
                column: "Account2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransfers_Bank2Id",
                table: "MoneyTransfers",
                column: "Bank2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyTransfers");
        }
    }
}
