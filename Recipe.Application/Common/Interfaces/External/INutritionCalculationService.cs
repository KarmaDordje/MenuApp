using ErrorOr;

using Recipe.Application.ApiModels;
using Recipe.Domain.Dtos;
using Recipe.Domain.IngredientAggregate;

namespace Recipe.Application.Interfaces
{
    public interface INutritionCalculationService
    {
        Task <Product> CalculateNutritionPerGramm(string polishName);
        ProductDTO CalculateNutritionPerPortion(Product ingredient, decimal portion);
    }
}