using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deiarts.Tools.Terminals.MathBudget.Migrations
{
    /// <inheritdoc />
    public partial class BudgetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Client = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Product = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    TimeServiceInMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetMaterial",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetMaterial", x => new { x.BudgetId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_BudgetMaterial_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetMaterial_MaterialId",
                table: "BudgetMaterial",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetMaterial");

            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
