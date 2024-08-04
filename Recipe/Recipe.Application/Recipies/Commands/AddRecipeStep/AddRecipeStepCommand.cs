namespace Recipe.Application.Recipes.Commands.AddRecipeStep
{
    using ErrorOr;
    using MediatR;
    using Recipe.Domain.Dtos;

    public record AddRecipeStepCommand(
        Guid RecipeId,
        int StepNumber,
        string StepDescription,
        string ImageUrl,
        string VideoUrl)
    : IRequest<ErrorOr<Guid>>;
}