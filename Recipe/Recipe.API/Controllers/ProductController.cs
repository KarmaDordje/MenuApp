namespace Recipe.API.Controllers
{
    using CleanArchitecture.Api.Controllers;
    using ErrorOr;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Recipe.API.RequestModels;
    using Recipe.Application.Ingredients.Commands.AddIngredient;
    using Recipe.Domain.Dtos;

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiController
    {
        private readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProductDTO>> AddIngredient([FromBody] AddProductRequest request)
        {
            var command = new AddProductCommand(request.IngredientName, request.Quantity);
            ErrorOr<ProductDTO> result = await _mediator.Send(command);

            return result.Match<ActionResult<ProductDTO>>(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
