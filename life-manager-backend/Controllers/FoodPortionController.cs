using AutoMapper;
using life_manager_backend.DbContexts;
using life_manager_backend.Entities;
using life_manager_backend.Models;
using life_manager_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace life_manager_backend.Controllers
{
    [Route("api/foodportion")]
    [ApiController]
    public class FoodPortionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFoodRepository _repository;

        public FoodPortionController(IMapper mapper, IFoodRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodPortionDto>>> GetFoodPortions(string? dateConsumed)
        {
            if (dateConsumed == null || dateConsumed == "")
            {
                var foodPortionEntities = await _repository.GetFoodPortionsAsync(true);
                return Ok(_mapper.Map<IEnumerable<FoodPortionDto>>(foodPortionEntities));
            }

            try
            {                
                var filteredFoodPortionEntities = await _repository.GetFoodPortionsByDateConsumedAsync(dateConsumed);
                return Ok(_mapper.Map<IEnumerable<FoodPortionDto>>(filteredFoodPortionEntities));
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetFoodPortion")]
        public async Task<ActionResult<FoodPortionDto>> GetFoodPortion(string id)
        {
            var foodPortionEntity = await _repository.GetFoodPortionByIdAsync(id);
            return Ok(_mapper.Map<FoodPortionDto>(foodPortionEntity));
        }

        [HttpPost]
        public async Task<ActionResult<FoodPortionDto>> CreateFoodPortion(FoodPortionForCreationDto foodPortion)
        {
            var foodPortionEntity = _mapper.Map<FoodPortion>(foodPortion);
            _repository.AddFoodPortion(foodPortionEntity);
            await _repository.SaveChangesAsync();            
            var foodPortionFromDatabase = await _repository.GetFoodPortionByIdAsync(foodPortionEntity.Id);
            var foodPortionToReturn = _mapper.Map<FoodPortionDto>(foodPortionFromDatabase);
            return CreatedAtRoute("GetFoodPortion", new { id = foodPortionToReturn.Id }, foodPortionToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFoodPortion(string id)
        {
            var foodPortionToDelete = await _repository.GetFoodPortionByIdAsync(id);

            if (foodPortionToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteFoodPortion(foodPortionToDelete);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
