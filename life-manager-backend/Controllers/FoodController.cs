using AutoMapper;
using life_manager_backend.DbContexts;
using life_manager_backend.Models;
using life_manager_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Controllers
{
    [Route("api/food")]
    [Authorize]
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
            var foodEntities = await _repository.GetFoodsAsync();
            var foodDtos = _mapper.Map<IEnumerable<FoodDto>>(foodEntities);
            return Ok(foodDtos);
        }

        [HttpGet("{id}", Name = "GetFood")]
        public async Task<ActionResult<FoodDto>> GetFood(string id)
        {
            var foodEntity = await _repository.GetFoodByIdAsync(id);
            if (foodEntity == null)
            {
                return NotFound();
            }
            var foodDto = _mapper.Map<FoodDto>(foodEntity);

            return Ok(foodDto);
        }

        [HttpPost]
        public async Task<ActionResult<FoodDto>> CreateFood(FoodForCreationDto food)
        {
            var foodEntity = _mapper.Map<Entities.Food>(food);
            _repository.AddFood(foodEntity);
            await _repository.SaveChangesAsync();
            var foodToReturn = _mapper.Map<FoodDto>(foodEntity);
            return CreatedAtRoute("GetFood", new { Id = foodToReturn.Id }, foodToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFood(string id)
        {
            var foodEntity = await _repository.GetFoodByIdAsync(id);

            if (foodEntity == null)
            {
                return NotFound();
            }

            _repository.DeleteFood(foodEntity);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
