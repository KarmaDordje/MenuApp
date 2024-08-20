namespace Recipe.Application.Recipes.Commands.DeleteIngredient
{
    using ErrorOr;
    using MediatR;
    public record DeleteRecipeSectionCommand(Guid RecipeId, Guid RecipeSectionId) : IRequest<ErrorOr<Unit>>;
}