using ErrorOr;
using MediatR;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand(
        string Name,
        string UserId,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<CreateRecipeStepCommand> RecipeSteps,
        List<CreateIngredientCommand> Ingredients
    ) : IRequest<ErrorOr<Domain.RecipeAggregate.Recipe>>;

    public record CreateIngredientCommand(string IngredientId, decimal Quantity);
    public record CreateRecipeStepCommand(int Order, string Name);
}