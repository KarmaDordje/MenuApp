namespace Recipe.Application.Interfaces
{
    using ErrorOr;
    using Recipe.Application.ApiModels;
    using Recipe.Domain.Dtos;
    using Recipe.Domain.IngredientAggregate;

    public interface INutritionCalculationService
    {
        Task <Product> CalculateNutritionPerGramm(string polishName);
        ProductDTO CalculateNutritionPerPortion(Product ingredient, decimal portion);
    }
}