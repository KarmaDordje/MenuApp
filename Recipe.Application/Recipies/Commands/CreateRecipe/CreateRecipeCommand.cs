using ErrorOr;
using MediatR;

using Recipe.Domain.Entities;
using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand(
        string Name,
        int UserId,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<RecipeStep> RecipeSteps,
        List<Ingredient> Ingredients
    ) : IRequest<ErrorOr<Domain.Entities.Recipe>>;

    public record Ingredient(string IngredientId, decimal Quantity);
    public record RecipeStep(int Order, string Name);
}