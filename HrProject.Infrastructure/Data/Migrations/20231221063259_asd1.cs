using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class asd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PmAnkrajIrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thick = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmAnkrajIrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmAnkrajIrons_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMProjectElementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    PozNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Similar = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    IronDiameterWeightId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMProjectElementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PMProjectElementDetails_IronDiameterWeights_IronDiameterWeightId",
                        column: x => x.IronDiameterWeightId,
                        principalTable: "IronDiameterWeights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMProjectElementDetails_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PmRopeIrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    ToronDiameterId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PmRopeIrons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PmRopeIrons_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PmRopeIrons_ToronDiameters_ToronDiameterId",
                        column: x => x.ToronDiameterId,
                        principalTable: "ToronDiameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PMWickerIronCalculates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PmCalculateId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Similar = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SteelMeshTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMWickerIronCalculates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PMWickerIronCalculates_PmCalculates_PmCalculateId",
                        column: x => x.PmCalculateId,
                        principalTable: "PmCalculates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PMWickerIronCalculates_SteelMeshType_SteelMeshTypeId",
                        column: x => x.SteelMeshTypeId,
                        principalTable: "SteelMeshType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PmAnkrajIrons_PmCalculateId",
                table: "PmAnkrajIrons",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_PMProjectElementDetails_IronDiameterWeightId",
                table: "PMProjectElementDetails",
                column: "IronDiameterWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_PMProjectElementDetails_PmCalculateId",
                table: "PMProjectElementDetails",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_PmRopeIrons_PmCalculateId",
                table: "PmRopeIrons",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_PmRopeIrons_ToronDiameterId",
                table: "PmRopeIrons",
                column: "ToronDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PMWickerIronCalculates_PmCalculateId",
                table: "PMWickerIronCalculates",
                column: "PmCalculateId");

            migrationBuilder.CreateIndex(
                name: "IX_PMWickerIronCalculates_SteelMeshTypeId",
                table: "PMWickerIronCalculates",
                column: "SteelMeshTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PmAnkrajIrons");

            migrationBuilder.DropTable(
                name: "PMProjectElementDetails");

            migrationBuilder.DropTable(
                name: "PmRopeIrons");

            migrationBuilder.DropTable(
                name: "PMWickerIronCalculates");
        }
    }
}
