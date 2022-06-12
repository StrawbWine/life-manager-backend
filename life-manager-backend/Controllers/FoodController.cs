using life_manager_backend.DbContexts;
using life_manager_backend.Models;
using life_manager_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Controllers
{
    [Route("api/food")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repository;

        public FoodController(IFoodRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foods = await _repository.GetFoodsAsync();
            return Ok(foods);
        }
    }
}
