using Recipe.Domain.Common.Errors;
using Recipe.Domain.Entities;

namespace Recipe.Contracts.Recipes
{
    public record CreateRecipeRequest(
        string Name,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<RecipeIngredient> Ingredients);
    public record RecipeIngredient(string Name, string Quantity);
}