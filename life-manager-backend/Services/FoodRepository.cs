using life_manager_backend.DbContexts;
using life_manager_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Services
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context;

        public FoodRepository(FoodContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Food?> GetFoodByIdAsync(string id)
        {
            return await _context.Foods.Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FoodPortion>> GetFoodPortionsAsync(bool includeFoodInfo)
        {
            if (includeFoodInfo)
            {
                return await _context.FoodPortions.Include(f => f.Food).ToListAsync();
            }
            return await _context.FoodPortions.ToListAsync();
        }

        public async Task<IEnumerable<FoodPortion>> GetFoodPortionsByDateConsumedAsync(string dateConsumed)
        {
            return await _context.FoodPortions
                .Where(f => f.DateConsumed == dateConsumed)
                .Include(f => f.Food)
                .ToListAsync();
        }

        public async Task<FoodPortion?> GetFoodPortionByIdAsync(string id)
        {
            return await _context.FoodPortions.Where(f => f.Id == id).Include(f => f.Food).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
        }

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
        }

        public void AddFoodPortion(FoodPortion foodPortion)
        {
            _context.FoodPortions.Add(foodPortion);
        }

        public void DeleteFoodPortion(FoodPortion foodPortion)
        {
            _context.FoodPortions.Remove(foodPortion);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
