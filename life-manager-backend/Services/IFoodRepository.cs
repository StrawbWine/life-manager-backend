using life_manager_backend.Entities;

namespace life_manager_backend.Services
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<Food?> GetFoodByIdAsync(string id);
        Task<IEnumerable<FoodPortion>> GetFoodPortionsAsync(bool includeFoodInfo);
        Task<IEnumerable<FoodPortion>> GetFoodPortionsByDateConsumedAsync(string dateConsumed);
        Task<FoodPortion?> GetFoodPortionByIdAsync(string id);
        void AddFood(Food food);
        void DeleteFood(Food food);

        void AddFoodPortion(FoodPortion foodPortion);
        void DeleteFoodPortion(FoodPortion foodPortion);
        Task<bool> SaveChangesAsync();
        Task<ApiUser?> GetApiUserAsync(string username, string password);
        
    }
}
