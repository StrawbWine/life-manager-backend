using life_manager_backend.Entities;

namespace life_manager_backend.Services
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoods();
        Task<Food?> GetFoodById(int id);
        Task<IEnumerable<FoodPortion>> GetFoodPortions(bool includeFoodInfo);
    }
}
