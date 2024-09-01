using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProject.Presentation.Data.Migrations
{
    /// <inheritdoc />
    public partial class aıaıaı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelInterDocs_PersonelAuthorities_PersonelAuthorityId",
                table: "PersonelInterDocs");

            migrationBuilder.DropIndex(
                name: "IX_PersonelInterDocs_PersonelAuthorityId",
                table: "PersonelInterDocs");

            migrationBuilder.DropColumn(
                name: "PersonelAuthorityId",
                table: "PersonelInterDocs");

            migrationBuilder.DropColumn(
                name: "SigningDate",
                table: "PersonelInterDocs");

            migrationBuilder.DropColumn(
                name: "SigningDocument",
                table: "PersonelInterDocs");

            migrationBuilder.AddColumn<int>(
                name: "PersonelInterDocId",
                table: "PersAddDocs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersAddDocs_PersonelInterDocId",
                table: "PersAddDocs",
                column: "PersonelInterDocId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersAddDocs_PersonelInterDocs_PersonelInterDocId",
                table: "PersAddDocs",
                column: "PersonelInterDocId",
                principalTable: "PersonelInterDocs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersAddDocs_PersonelInterDocs_PersonelInterDocId",
                table: "PersAddDocs");

            migrationBuilder.DropIndex(
                name: "IX_PersAddDocs_PersonelInterDocId",
                table: "PersAddDocs");

            migrationBuilder.DropColumn(
                name: "PersonelInterDocId",
                table: "PersAddDocs");

            migrationBuilder.AddColumn<int>(
                name: "PersonelAuthorityId",
                table: "PersonelInterDocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SigningDate",
                table: "PersonelInterDocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SigningDocument",
                table: "PersonelInterDocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelInterDocs_PersonelAuthorityId",
                table: "PersonelInterDocs",
                column: "PersonelAuthorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelInterDocs_PersonelAuthorities_PersonelAuthorityId",
                table: "PersonelInterDocs",
                column: "PersonelAuthorityId",
                principalTable: "PersonelAuthorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
