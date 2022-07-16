using life_manager_backend.Models;

namespace life_manager_backend
{
    public class InMemoryDataStore
    {
        public List<FoodDto> Foods;

        public InMemoryDataStore()
        {
            Foods = CreateFoodData();
        }

        private List<FoodDto> CreateFoodData()
        {
            var foods = new List<FoodDto>();
            foods.Add(new FoodDto()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Spaghetti a la Capri",
                Energy = 99,
                Fat = 4.10,
                SaturatedFat = 0.90,
                Carbohydrates = 12.0,
                Sugars = 2.60,
                Fiber = 0.0,
                Protein = 3.50,
                Salt = 0.85
            });
            return foods;
        }
    }
}
