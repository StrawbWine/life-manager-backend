namespace life_manager_backend.Models
{
    public class FoodDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int? Energy { get; set; }
        public int? Fat { get; set; }
        public int? SaturatedFat { get; set; }
        public int? MonoUnsaturatedFat { get; set; }
        public int? PolyUnsaturatedFat { get; set; }
        public int? Carbohydrates { get; set; }
        public int? Sugars { get; set; }
        public int? Protein { get; set; }
        public int? Salt { get; set; }
        public int? Fiber { get; set; }
    }
}
