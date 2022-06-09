using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace life_manager_backend.Migrations
{
    public partial class addsingledatapoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Carbohydrates", "Energy", "Fat", "Fiber", "MonoUnsaturatedFat", "Name", "PolyUnsaturatedFat", "Protein", "Salt", "SaturatedFat", "Sugars" },
                values: new object[] { 1L, 12.0, 99.0, 4.0999999999999996, 0.0, null, "Spaghetti a la Capri", null, 3.5, 0.84999999999999998, 0.90000000000000002, 2.6000000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
