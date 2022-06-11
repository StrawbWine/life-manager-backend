using AutoMapper;

namespace life_manager_backend.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Entities.Food, Models.FoodDto>();            
        }
    }
}
