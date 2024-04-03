
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
        private readonly ISender _mediator;

    public RecipeController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

       [HttpPost]
       public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request, int userId)
       {
            var commnad = _mapper.Map<CreateRecipeCommand>(request);
            var createRecipeResult = await _mediator.Send(commnad);
            return createRecipeResult.Match(
                recipe => Ok(_mapper.Map<CreateRecipeResponse>(recipe)),
                errors => Problem(errors));
       }
    }
}