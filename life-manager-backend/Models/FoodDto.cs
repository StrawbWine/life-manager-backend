namespace life_manager_backend.Models
{
    public class FoodDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public double? Energy { get; set; }
        public double? Fat { get; set; }
        public double? SaturatedFat { get; set; }
        public double? MonoUnsaturatedFat { get; set; }
        public double? PolyUnsaturatedFat { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Sugars { get; set; }
        public double? Protein { get; set; }
        public double? Salt { get; set; }
        public double? Fiber { get; set; }
    }
}
