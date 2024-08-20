namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    using ErrorOr;
    using MediatR;
    using Recipe.Domain.Dtos;

    public record AddIngredientCommand(Guid RecipeId, Guid RecipeSectionId, string IngredientName, decimal Quantity)
    : IRequest<ErrorOr<ProductDTO>>;
}