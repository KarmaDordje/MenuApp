namespace Recipe.API.Controllers
{
    using CleanArchitecture.Api.Controllers;
    using Mapster;
    using MapsterMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    using Recipe.Application.Recipes;
    using Recipe.Application.Recipes.Commands.AddRecipeSection;

    using Recipe.Application.Recipes.Commands.AddRecipeStep;

    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Application.Recipes.Commands.DeleteIngredient;
    using Recipe.Application.Recipes.Commands.DeleteRecipeStep;
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

        [HttpPost("AddRecipeSection")]
        public async Task<IActionResult> AddRecipeSection(AddRecipeSectionRequest request)
        {
            var command = _mapper.Map<AddRecipeSectionCommand>(request);
            var addRecipeSectionResult = await _mediator.Send(command);
            return addRecipeSectionResult.Match(
                sectionId => Ok(sectionId),
                errors => Problem(errors));
        }

        [HttpPost("AddIngredient")]
        public async Task<IActionResult> AddIngredient(AddIngredientRequest request)
        {
           var command = _mapper.Map<AddIngredientCommand>(request);
           var addIngredientResult = await _mediator.Send(command);
           return addIngredientResult.Match(
               product => Ok(product),
               errors => Problem(errors));
        }

        [HttpPost("AddRecipeStep")]
        public async Task<IActionResult> AddRecipeStep(AddRecipeStepRequest request)
        {
            var command = _mapper.Map<AddRecipeStepCommand>(request);
            var addRecipeStepResult = await _mediator.Send(command);
            return addRecipeStepResult.Match(
                stepId => Ok(stepId),
                errors => Problem(errors));
        }

        [HttpDelete("DeleteIngredient")]
        public async Task<IActionResult> DeleteIngredient(DeleteIngredientRequest request)
        {
            var command = _mapper.Map<DeleteIngredientCommand>(request);
            var deleteIngredientResult = await _mediator.Send(command);
            return deleteIngredientResult.Match(
                _ => Ok(),
                errors => Problem(errors));
        }

        [HttpDelete("DeleteRecipeSection")]
        public async Task<IActionResult> DeleteRecipeSection(DeleteRecipeSectionRequest request)
        {
            var command = _mapper.Map<DeleteRecipeSectionCommand>(request);
            var deleteRecipeSectionResult = await _mediator.Send(command);
            return deleteRecipeSectionResult.Match(
                _ => Ok(),
                errors => Problem(errors));
        }

        [HttpDelete("DeleteRecipeStep")]
        public async Task<IActionResult> DeleteRecipeStep(DeleteRecipeStepRequest request)
        {
            var command = _mapper.Map<DeleteRecipeStepCommand>(request);
            var deleteRecipeStepResult = await _mediator.Send(command);
            return deleteRecipeStepResult.Match(
                _ => Ok(),
                errors => Problem(errors));
        }
    }
}