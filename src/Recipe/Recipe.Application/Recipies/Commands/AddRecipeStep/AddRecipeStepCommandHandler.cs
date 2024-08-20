namespace Recipe.Application.Recipes.Commands.AddRecipeStep
{
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Domain.ValueObjects;
    using RecipeStep = Recipe.Domain.RecipeAggregate.Entities.RecipeStep;

    public class AddRecipeStepCommandHandler : IRequestHandler<AddRecipeStepCommand, ErrorOr<Guid>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public AddRecipeStepCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Guid>> Handle(AddRecipeStepCommand request, CancellationToken cancellationToken)
        {
            if (await _recipeRepository.GetAsync(RecipeId.Create(request.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                return Domain.Common.Errors.RecipeErrors.RecipeStep.RecipeNotFound;
            }

            var step = RecipeStep.Create(request.StepNumber, request.StepDescription, request.ImageUrl, request.VideoUrl);
            recipe.AddStep(step);
            await _recipeRepository.UpdateAsync(recipe);

            return step.Id.Value;
        }
    }
}