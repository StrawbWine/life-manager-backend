using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace life_manager_backend.Migrations
{
    public partial class addsinglefoodportiondatapoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodPortions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FoodId = table.Column<long>(type: "bigint", nullable: false),
                    WeightInGrams = table.Column<int>(type: "int", nullable: false),
                    DateConsumed = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPortions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPortions_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "FoodPortions",
                columns: new[] { "Id", "DateConsumed", "FoodId", "WeightInGrams" },
                values: new object[] { 1L, new DateOnly(2022, 6, 10), 1L, 870 });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPortions_FoodId",
                table: "FoodPortions",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodPortions");
        }
    }
}
