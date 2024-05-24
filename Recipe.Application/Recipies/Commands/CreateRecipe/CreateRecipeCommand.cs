using ErrorOr;
using MediatR;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand(
        string Name,
        string UserId) : IRequest<ErrorOr<Guid>>;
}