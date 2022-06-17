using life_manager_backend.Entities;

namespace life_manager_backend.Services
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<Food?> GetFoodByIdAsync(long id);
        Task<IEnumerable<FoodPortion>> GetFoodPortionsAsync(bool includeFoodInfo);
        void AddFood(Food food);
        void DeleteFood(Food food);
        Task<bool> SaveChangesAsync();
    }
}
