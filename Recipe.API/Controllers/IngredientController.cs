using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.RequestModels;
using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Domain.Dtos;

namespace Recipe.API.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly ISender _mediator;

        public IngredientController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddIngredient")]
        [ProducesResponseType(typeof(IngredientDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IngredientDTO>> AddIngredient([FromBody] AddIngredientRequest request)
        {
            var command = new AddIngredientCommand(request.IngredientName, request.Quantity);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

   