using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace life_manager_backend.Migrations
{
    public partial class initial_setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Energy = table.Column<double>(type: "double", nullable: true),
                    Fat = table.Column<double>(type: "double", nullable: true),
                    SaturatedFat = table.Column<double>(type: "double", nullable: true),
                    MonoUnsaturatedFat = table.Column<double>(type: "double", nullable: true),
                    PolyUnsaturatedFat = table.Column<double>(type: "double", nullable: true),
                    Carbohydrates = table.Column<double>(type: "double", nullable: true),
                    Sugars = table.Column<double>(type: "double", nullable: true),
                    Protein = table.Column<double>(type: "double", nullable: true),
                    Salt = table.Column<double>(type: "double", nullable: true),
                    Fiber = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
