namespace Recipe.Contracts.Recipes
{
    using System;
    using ErrorOr;
    using MediatR;

    public record AddRecipeStepRequest(
        Guid RecipeId, int StepNumber,
        string StepDescription,
        string ImageUrl,
        string VideoUrl)
    : IRequest<ErrorOr<Guid>>;
}