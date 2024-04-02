using ErrorOr;
using MediatR;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand(
        string Name,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<RecipeIngredient> Ingredients
    ) : IRequest<ErrorOr<Domain.Entities.Recipe>>;

    public record RecipeIngredient(string Name, string Quantity);
}