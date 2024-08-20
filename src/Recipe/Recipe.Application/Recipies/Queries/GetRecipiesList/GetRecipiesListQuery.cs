namespace Recipe.Application.Recipes.Queries.GetRecipiesList;
using MediatR;
using ErrorOr;
using Recipe.Contracts.Recipes.GetRecipeResponse;

public class GetRecipiesListQuery : IRequest<ErrorOr<RecipiesListResponse>>
{
    public string UserId { get; set; }
}