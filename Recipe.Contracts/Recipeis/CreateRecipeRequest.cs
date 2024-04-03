using Recipe.Domain.Common.Errors;
using Recipe.Domain.Entities;
using Recipe.Domain.ValueObjects;

namespace Recipe.Contracts.Recipes
{
    public record CreateRecipeRequest(
        string Name,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<RecipeStep> RecipeSteps,
        List<Ingredient> Ingredients);
    public record Ingredient(
        string Name,
        string PolishName,
        decimal Calories,
        decimal Cholesterol,
        decimal FatSaturated,
        decimal FatTotal,
        int MeasuresType,
        decimal Potassium,
        decimal Protein,
        decimal Sodium,
        Measurement Measurement
    );
    public record RecipeStep(int Order, string Name);
}