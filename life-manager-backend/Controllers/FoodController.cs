using life_manager_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace life_manager_backend.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;

        public FoodController(InMemoryDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foods = _dataStore.Foods;
            return Ok(foods);
        }
    }
}
