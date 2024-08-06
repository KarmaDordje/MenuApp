namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    using ErrorOr;
    using MediatR;
    using Recipe.Contracts.Recipes;
    using Recipe.Domain.Common.Shared;

    public record CreateRecipeCommand(
        string Name,
        string UserId,
        string SectionName,
        Category Category) : IRequest<ErrorOr<CreateRecipeResponse>>;
}