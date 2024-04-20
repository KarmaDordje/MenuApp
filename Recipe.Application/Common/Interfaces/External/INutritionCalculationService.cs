using Recipe.Application.ApiModels;
using Recipe.Domain.Dtos;
using Recipe.Domain.IngredientAggregate;

namespace Recipe.Application.Interfaces
{
    public interface INutritionCalculationService
    {
        Ingredient CalculateNutritionPerGramm(NutritionResponse nutrition, string polishName);
        IngredientDTO CalculateNutritionPerPortion(Ingredient ingredient, decimal portion);
    }
}