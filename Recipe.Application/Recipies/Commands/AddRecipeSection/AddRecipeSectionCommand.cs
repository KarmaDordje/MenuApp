namespace Recipe.Application.Recipes.Commands.AddRecipeSection
{
    using ErrorOr;
    using MediatR;
    using Recipe.Contracts.Recipes;
    public record AddRecipeSectionCommand(Guid RecipeId, string Title) : IRequest<ErrorOr<AddRecipeSectionResponse>>;
}