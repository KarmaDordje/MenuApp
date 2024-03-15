using AutoMapper;
using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Dtos;
using Recipe.Domain.Entities;

namespace Recipe.Application.Services 
{
    public class NutritionCalculationService : INutritionCalculationService
    {   
        private readonly IMapper _mapper;

        public NutritionCalculationService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Ingredient CalculateNutritionPerGramm(NutritionResponse nutrition)
        {   
            var result =  _mapper.Map<Ingredient>(nutrition);
            return result;
        }

        IngredientDTO INutritionCalculationService.CalculateNutritionPerPortion(Ingredient ingredient, decimal portion)
        {
            throw new NotImplementedException();
        }
    }
}