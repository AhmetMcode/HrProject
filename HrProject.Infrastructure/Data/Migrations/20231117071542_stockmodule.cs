using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class stockmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KDV",
                table: "Stocks");

            migrationBuilder.AddColumn<bool>(
                name: "Buyable",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyingDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BuyingWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyingWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EDocumentBaseRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxControl",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxStock",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinControl",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinStock",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseVatId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SaleDiscountRate",
                table: "Stocks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SaleVatId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Saleable",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SalesWithholdingRateId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesWithholdingTypeId",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Variant",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VariantDescription",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BuyingWithholdingRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithHRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingWithholdingRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyingWithholdingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithHName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyingWithholdingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDocumentBaseRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDocumentBaseRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseVats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesWithholdingRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithHRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesWithholdingRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesWithholdingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithHType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesWithholdingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleVats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleVats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BuyingWithholdingRateId",
                table: "Stocks",
                column: "BuyingWithholdingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_BuyingWithholdingTypeId",
                table: "Stocks",
                column: "BuyingWithholdingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_EDocumentBaseRateId",
                table: "Stocks",
                column: "EDocumentBaseRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PurchaseVatId",
                table: "Stocks",
                column: "PurchaseVatId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SalesWithholdingRateId",
                table: "Stocks",
                column: "SalesWithholdingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SalesWithholdingTypeId",
                table: "Stocks",
                column: "SalesWithholdingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SaleVatId",
                table: "Stocks",
                column: "SaleVatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks",
                column: "BuyingWithholdingRateId",
                principalTable: "BuyingWithholdingRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks",
                column: "BuyingWithholdingTypeId",
                principalTable: "BuyingWithholdingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks",
                column: "EDocumentBaseRateId",
                principalTable: "EDocumentBaseRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks",
                column: "PurchaseVatId",
                principalTable: "PurchaseVats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks",
                column: "SaleVatId",
                principalTable: "SaleVats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks",
                column: "SalesWithholdingRateId",
                principalTable: "SalesWithholdingRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks",
                column: "SalesWithholdingTypeId",
                principalTable: "SalesWithholdingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingRates_BuyingWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BuyingWithholdingTypes_BuyingWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_EDocumentBaseRates_EDocumentBaseRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_PurchaseVats_PurchaseVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SaleVats_SaleVatId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingRates_SalesWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_SalesWithholdingTypes_SalesWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "BuyingWithholdingRates");

            migrationBuilder.DropTable(
                name: "BuyingWithholdingTypes");

            migrationBuilder.DropTable(
                name: "EDocumentBaseRates");

            migrationBuilder.DropTable(
                name: "PurchaseVats");

            migrationBuilder.DropTable(
                name: "SalesWithholdingRates");

            migrationBuilder.DropTable(
                name: "SalesWithholdingTypes");

            migrationBuilder.DropTable(
                name: "SaleVats");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BuyingWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_BuyingWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_EDocumentBaseRateId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_PurchaseVatId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_SalesWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_SalesWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_SaleVatId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Buyable",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "BuyingDiscountRate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "BuyingWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "BuyingWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "EDocumentBaseRateId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MaxControl",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MaxStock",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MinControl",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MinStock",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "PurchaseVatId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SaleDiscountRate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SaleVatId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Saleable",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SalesWithholdingRateId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SalesWithholdingTypeId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Variant",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "VariantDescription",
                table: "Stocks");

            migrationBuilder.AddColumn<double>(
                name: "KDV",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
