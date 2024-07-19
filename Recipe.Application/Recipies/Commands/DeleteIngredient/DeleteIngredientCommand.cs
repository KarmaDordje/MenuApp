namespace Recipe.Application.Recipes;

using ErrorOr;
using MediatR;

public record DeleteIngredientCommand : IRequest<ErrorOr<Unit>>
{
    public Guid RecipeId { get; init; }
    public Guid RecipeSectionId { get; init; }
    public Guid IngredientId { get; init; }
}