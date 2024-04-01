using ErrorOr;

using MediatR;

using Recipe.Domain.Dtos;

namespace Recipe.Application.Ingredients.Commands.AddIngredient
{
    public record AddIngredientCommand(string IngredientName, decimal Quantity) : IRequest<ErrorOr<IngredientDTO>>;
}