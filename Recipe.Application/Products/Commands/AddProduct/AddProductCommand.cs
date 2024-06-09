namespace Recipe.Application.Ingredients.Commands.AddIngredient
{
    using ErrorOr;
    using MediatR;
    using Recipe.Domain.Dtos;


    public record AddProductCommand(string IngredientName, decimal Quantity) : IRequest<ErrorOr<ProductDTO>>;
}