using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deiarts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropsInRawMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CostPerUnit",
                table: "RawMaterials",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasure",
                table: "RawMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPerUnit",
                table: "RawMaterials");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "RawMaterials");
        }
    }
}
