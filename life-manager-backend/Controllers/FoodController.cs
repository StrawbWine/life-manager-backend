using life_manager_backend.DbContexts;
using life_manager_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;
        private readonly FoodContext _context;

        public FoodController(InMemoryDataStore dataStore, FoodContext context)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            //var foods = _dataStore.Foods;
            var foods = await _context.Foods.ToListAsync();
            return Ok(foods);
        }
    }
}
