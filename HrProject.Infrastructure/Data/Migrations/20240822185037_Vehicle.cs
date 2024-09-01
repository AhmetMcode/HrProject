using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class Vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kilometer",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleKilometerUpdate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    LastKilometer = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleKilometerUpdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleKilometerUpdate_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleKilometerUpdate_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    LenderUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLend_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLend_AspNetUsers_LenderUserId",
                        column: x => x.LenderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleLend_Personals_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLend_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleKilometerUpdate_ApplicationUserId",
                table: "VehicleKilometerUpdate",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleKilometerUpdate_VehicleId",
                table: "VehicleKilometerUpdate",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLend_ApplicationUserId",
                table: "VehicleLend",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLend_LenderUserId",
                table: "VehicleLend",
                column: "LenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLend_PersonId",
                table: "VehicleLend",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLend_VehicleId",
                table: "VehicleLend",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleKilometerUpdate");

            migrationBuilder.DropTable(
                name: "VehicleLend");

            migrationBuilder.DropColumn(
                name: "Kilometer",
                table: "Vehicles");
        }
    }
}
