using AutoMapper;
using Recipe.Domain.Dtos;
using Recipe.Infrastructure.Context.Entities;
using Recipe.Infrastructure.External.Models;

namespace Recipe.Domain.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Ingredient, IngredientDTO>().ReverseMap();

            CreateMap<NutritionResponse, Ingredient>().ReverseMap();
            
        }
    }
}
