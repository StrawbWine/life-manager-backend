using life_manager_backend.DbContexts;
using life_manager_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Services
{
    public class CosmosRepository : IFoodRepository
    {
        private readonly CosmosContext _context;

        public CosmosRepository(CosmosContext _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
        }

        public void AddFoodPortion(FoodPortion foodPortion)
        {
            _context.FoodPortions.Add(foodPortion);
        }

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
        }

        public void DeleteFoodPortion(FoodPortion foodPortion)
        {
            _context.FoodPortions.Remove(foodPortion);
        }

        public async Task<Food?> GetFoodByIdAsync(string id)
        {
            return await _context.Foods.Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<FoodPortion?> GetFoodPortionByIdAsync(string id)
        {
            var foodPortion = await _context.FoodPortions.Where(f => f.Id == id).FirstOrDefaultAsync();
            var foodPortionEntry = _context.Entry(foodPortion);
            await foodPortionEntry
                .Reference(f => f.Food)
                .LoadAsync();
            return foodPortion;
        }

        public async Task<IEnumerable<FoodPortion>> GetFoodPortionsAsync(bool includeFoodInfo)
        {
            var foodPortions = await _context.FoodPortions.ToListAsync();
            if (includeFoodInfo)
            {                
                foreach(var foodPortion in foodPortions)
                {
                    var foodPortionEntry = _context.Entry(foodPortion);
                    await foodPortionEntry
                        .Reference(f => f.Food)
                        .LoadAsync();
                }                
            }
            return foodPortions;
        }

        public async Task<IEnumerable<FoodPortion>> GetFoodPortionsByDateConsumedAsync(string dateConsumed)
        {            
            var foodPortions = await _context.FoodPortions.Where(f => f.DateConsumed == dateConsumed).ToListAsync();
            foreach (var foodPortion in foodPortions)
            {
                var foodPortionEntry = _context.Entry(foodPortion);
                await foodPortionEntry
                    .Reference(f => f.Food)
                    .LoadAsync();
            }
            return foodPortions;
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
