namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    using ErrorOr;
    using MediatR;


    public record CreateRecipeCommand(
        string Name,
        string UserId) : IRequest<ErrorOr<Guid>>;
}