using AutoMapper;
using life_manager_backend.DbContexts;
using life_manager_backend.Models;
using life_manager_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<FoodPortionDto>>> GetFoodPortions()
        {
            var foodPortionEntity = await _repository.GetFoodPortions(true);
            return Ok(_mapper.Map<IEnumerable<FoodPortionDto>>(foodPortionEntity));
        }
    }
}
