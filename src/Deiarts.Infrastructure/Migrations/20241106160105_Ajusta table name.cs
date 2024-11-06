using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deiarts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Ajustatablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RawMaterial",
                table: "RawMaterial");

            migrationBuilder.RenameTable(
                name: "RawMaterial",
                newName: "RawMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RawMaterials",
                table: "RawMaterials",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RawMaterials",
                table: "RawMaterials");

            migrationBuilder.RenameTable(
                name: "RawMaterials",
                newName: "RawMaterial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RawMaterial",
                table: "RawMaterial",
                column: "Id");
        }
    }
}
