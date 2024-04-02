
using CleanArchitecture.Api.Controllers;
using Mapster;

using MapsterMapper;


using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Recipes.Commands.CreateRecipe;
using Recipe.Contracts.Recipes;

namespace Recipe.API.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

    public RecipeController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

       [HttpPost]
       public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeRequest request)
       {
            var commnad = _mapper.Map<CreateRecipeCommand>(request);
            var createMenuRequest = await _mediator.Send(commnad);
            return Ok(commnad);
       }
    }
}