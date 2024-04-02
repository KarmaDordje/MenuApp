using CleanArchitecture.Api.Controllers;

using ErrorOr;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Recipe.API.RequestModels;
using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Domain.Dtos;

namespace Recipe.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ApiController
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
            ErrorOr<IngredientDTO> result = await _mediator.Send(command);

            return result.Match<ActionResult<IngredientDTO>>(
                result => Ok(result),
                errors => Problem(errors));
        }
    }
}
