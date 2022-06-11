using life_manager_backend.Utilities;

namespace life_manager_backend.Models
{
    public class FoodPortionDto
    {
        public long Id { get; set; }
        public FoodDto Food { get; set; }
        public int WeightInGrams { get; set; }
        public DateTime DateConsumed { get; set; }
        public double? Energy => FoodPortionUtilities.calculateTotalContent(Food.Energy, WeightInGrams);
        public double? Fat => FoodPortionUtilities.calculateTotalContent(Food.Fat, WeightInGrams);
        public double? SaturatedFat => FoodPortionUtilities.calculateTotalContent(Food.SaturatedFat, WeightInGrams);
        public double? MonoUnsaturatedFat => FoodPortionUtilities.calculateTotalContent(Food.MonoUnsaturatedFat, WeightInGrams);

        public double? PolyUnsaturatedFat => FoodPortionUtilities.calculateTotalContent(Food.PolyUnsaturatedFat, WeightInGrams);
        public double? Carbohydrates => FoodPortionUtilities.calculateTotalContent(Food.Carbohydrates, WeightInGrams);
        public double? Sugars => FoodPortionUtilities.calculateTotalContent(Food.Sugars, WeightInGrams);
        public double? Protein => FoodPortionUtilities.calculateTotalContent(Food.Protein, WeightInGrams);
        public double? Salt => FoodPortionUtilities.calculateTotalContent(Food.Salt, WeightInGrams);
        public double? Fiber => FoodPortionUtilities.calculateTotalContent(Food.Fiber, WeightInGrams);
    }
}
