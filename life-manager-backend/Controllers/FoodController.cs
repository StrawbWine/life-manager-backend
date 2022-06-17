using AutoMapper;
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
        private readonly IMapper _mapper;

        public FoodController(IFoodRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetFoods()
        {
            var foods = await _repository.GetFoodsAsync();
            return Ok(foods);
        }

        [HttpGet("{foodid}", Name = "GetFood")]
        public async Task<ActionResult<FoodDto>> GetFood(long foodId)
        {
            var foodEntity = await _repository.GetFoodByIdAsync(foodId);
            if (foodEntity == null)
            {
                return NotFound();
            }

            return Ok(foodEntity);
        }

        [HttpPost]
        public async Task<ActionResult<FoodDto>> CreateFood(FoodForCreationDto food)
        {
            var foodEntity = _mapper.Map<Entities.Food>(food);
            _repository.AddFood(foodEntity);
            await _repository.SaveChangesAsync();
            var foodToReturn = _mapper.Map<FoodDto>(foodEntity);
            return CreatedAtRoute("GetFood", new { foodId = foodToReturn.Id }, foodToReturn);
        }
    }
}
