using Recipe.Application.ApiModels;
using Recipe.Domain.Dtos;
using Recipe.Domain.Entities;

namespace Recipe.Application.Interfaces
{
    public interface INutritionCalculationService
    {
        Ingredient CalculateNutritionPerGramm(NutritionResponse nutrition);
        IngredientDTO CalculateNutritionPerPortion(Ingredient ingredient, decimal portion);
    }
}