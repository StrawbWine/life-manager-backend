namespace life_manager_backend.Utilities
{
    public static class FoodPortionUtilities
    {
        public static double? calculateTotalContent(double? amountPerHundredGrams, int weightInGrams) {
            if (amountPerHundredGrams == null) return null;
            return Math.Round((double)amountPerHundredGrams * weightInGrams / 100, 2, MidpointRounding.AwayFromZero);
        }
    }
}
