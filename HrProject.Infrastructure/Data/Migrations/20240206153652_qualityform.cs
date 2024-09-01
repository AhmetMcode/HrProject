using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class qualityform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityFormSub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionStepId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFormSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityFormSub_ProductionStep_ProductionStepId",
                        column: x => x.ProductionStepId,
                        principalTable: "ProductionStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityFormSubAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityFormFinalType = table.Column<int>(type: "int", nullable: false),
                    QualityFormSubId = table.Column<int>(type: "int", nullable: false),
                    ProjectModuleSubId = table.Column<int>(type: "int", nullable: false),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    ManifactDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastControlDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GermePersonId = table.Column<int>(type: "int", nullable: true),
                    UretimPersonId = table.Column<int>(type: "int", nullable: true),
                    ControlPersonId = table.Column<int>(type: "int", nullable: true),
                    LastControlPersonId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityFormSubAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_Personals_ControlPersonId",
                        column: x => x.ControlPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_Personals_GermePersonId",
                        column: x => x.GermePersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_Personals_LastControlPersonId",
                        column: x => x.LastControlPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_Personals_UretimPersonId",
                        column: x => x.UretimPersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_ProjectModuleSub_ProjectModuleSubId",
                        column: x => x.ProjectModuleSubId,
                        principalTable: "ProjectModuleSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityFormSubAnswer_QualityFormSub_QualityFormSubId",
                        column: x => x.QualityFormSubId,
                        principalTable: "QualityFormSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityFormSubId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QualityFormSub_QualityFormSubId",
                        column: x => x.QualityFormSubId,
                        principalTable: "QualityFormSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerType = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSub_ProductionStepId",
                table: "QualityFormSub",
                column: "ProductionStepId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_ControlPersonId",
                table: "QualityFormSubAnswer",
                column: "ControlPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_GermePersonId",
                table: "QualityFormSubAnswer",
                column: "GermePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_LastControlPersonId",
                table: "QualityFormSubAnswer",
                column: "LastControlPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_PmCalculateId",
                table: "QualityFormSubAnswer",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_ProjectModuleSubId",
                table: "QualityFormSubAnswer",
                column: "ProjectModuleSubId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_QualityFormSubId",
                table: "QualityFormSubAnswer",
                column: "QualityFormSubId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityFormSubAnswer_UretimPersonId",
                table: "QualityFormSubAnswer",
                column: "UretimPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QualityFormSubId",
                table: "Question",
                column: "QualityFormSubId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityFormSubAnswer");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QualityFormSub");
        }
    }
}
