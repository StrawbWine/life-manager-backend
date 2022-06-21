using AutoMapper;

namespace life_manager_backend.Profiles
{
    public class FoodPortionProfile : Profile
    {
        public FoodPortionProfile()
        {
            CreateMap<Entities.FoodPortion, Models.FoodPortionDto>();
            CreateMap<Models.FoodPortionForCreationDto, Entities.FoodPortion>();
        }
    }
}
