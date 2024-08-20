namespace Recipe.Application.Recipes.Commands.DeleteRecipeStep
{
    using ErrorOr;
    using MediatR;
    public record DeleteRecipeStepCommand(Guid RecipeId, Guid RecipeStepId) : IRequest<ErrorOr<Unit>>;
}