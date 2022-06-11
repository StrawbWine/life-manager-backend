using AutoMapper;
using life_manager_backend.DbContexts;
using life_manager_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace life_manager_backend.Controllers
{
    [Route("api/foodportion")]
    [ApiController]
    public class FoodPortionController : ControllerBase
    {
        
        private readonly FoodContext _context;
        private readonly IMapper _mapper;

        public FoodPortionController(FoodContext context, IMapper mapper)
        {            
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodPortionDto>>> GetFoodPortions()
        {            
            var foods = await _context.FoodPortions.Include(fp => fp.Food).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<FoodPortionDto>>(foods));
        }
    }
}
