namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    using ErrorOr;
    using MediatR;
    using Recipe.Contracts.Recipes;
    public record CreateRecipeCommand(
        string Name,
        string UserId,
        string SectionName) : IRequest<ErrorOr<CreateRecipeResponse>>;
}