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
        List<RecipeIngredient> Ingredients);
    public record RecipeIngredient(string IngredientId, decimal Quantity);
    public record RecipeStep(int Order, string Name);
}