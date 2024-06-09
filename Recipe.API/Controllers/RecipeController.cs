namespace Recipe.API.Controllers
{
    using CleanArchitecture.Api.Controllers;
    using Mapster;
    using MapsterMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Contracts.Recipes;

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
        public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
       {
            var commnad = _mapper.Map<CreateRecipeCommand>(request);
            var createRecipeResult = await _mediator.Send(commnad);
            return createRecipeResult.Match(
                recipeId => Ok(recipeId),
                errors => Problem(errors));
       }
    }
}