using AutoMapper;
using Recipe.Domain.Dtos;
using Recipe.Infrastructure.Context.Entities;


namespace Recipe.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();
        }
    }
}
