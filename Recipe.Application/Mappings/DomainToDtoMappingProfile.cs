using AutoMapper;
using Recipe.Domain.Dtos;
using Recipe.Domain.Entities;

namespace Recipe.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
            
        }
    }
}
