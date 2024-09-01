﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ilksayimchange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockChangeEnum",
                table: "StockSub",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockChangeEnum",
                table: "StockSub");
        }
    }
}
