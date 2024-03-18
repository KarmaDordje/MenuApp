using MediatR;
using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Domain.Dtos;

namespace Recipe.Application.Common.Behavior
{
    public class ValidationAddEngredientBehavior: 
    IPipelineBehavior<AddIngredientCommand, IngredientDTO>
    {
        public async Task<IngredientDTO> Handle(
            AddIngredientCommand request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<IngredientDTO> next)
        {
            if (request.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            return await next();
        }

        public async Task<IngredientDTO> Handle(AddIngredientCommand request, RequestHandlerDelegate<IngredientDTO> next, CancellationToken cancellationToken)
        {   
            if (request.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            var result = await next();
            return result;
        }
    }
}