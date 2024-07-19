namespace Recipe.Application.Recipes.Commands.DeleteRecipeStep
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Domain.ValueObjects;

    public class DeleteRecipeStepCommandHandler : IRequestHandler<DeleteRecipeStepCommand, ErrorOr<Unit>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public DeleteRecipeStepCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteRecipeStepCommand request, CancellationToken cancellationToken)
        {
            if (await _recipeRepository.GetAsync(RecipeId.Create(request.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                return Domain.Common.Errors.RecipeErrors.RecipeStep.RecipeNotFound;
            }

            recipe.DeleteRecipeStep(RecipeStepId.Create(request.RecipeStepId));
            await _recipeRepository.UpdateAsync(recipe);

            return Unit.Value;
        }
    }
}