using ErrorOr;

using MediatR;

using Recipe.Domain.Dtos;

namespace Recipe.Application.Ingredients.Commands.AddIngredient
{
    public record AddProductCommand(string IngredientName, decimal Quantity) : IRequest<ErrorOr<ProductDTO>>;
}