namespace Recipe.Application.Recipes.Queries
{
    using System;
    using ErrorOr;
    using MediatR;
    using Recipe.Contracts.Recipes;

    public record RecipeQuery(Guid RecipeId) : IRequest<ErrorOr<RecipeGetResponse>>;

}