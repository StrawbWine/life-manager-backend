using life_manager_backend.Entities;

namespace life_manager_backend.Services
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<Food?> GetFoodByIdAsync(long id);
        Task<IEnumerable<FoodPortion>> GetFoodPortionsAsync(bool includeFoodInfo);
        Task<FoodPortion?> GetFoodPortionByIdAsync(long foodPortionId);
        void AddFood(Food food);
        void DeleteFood(Food food);

        void AddFoodPortion(FoodPortion foodPortion);
        void DeleteFoodPortion(FoodPortion foodPortion);
        Task<bool> SaveChangesAsync();
        
    }
}
