namespace Recipe.Application.Recipes.Commands.DeleteIngredient
{
    using System.Threading;
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Domain.IngredientAggregate;
    using Recipe.Domain.IngredientAggregate.ValueObjects;
    using Recipe.Domain.RecipeAggregate.ValueObjects;

    using Recipe.Domain.ValueObjects;

    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, ErrorOr<Unit>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public DeleteIngredientCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            if (await _recipeRepository.GetAsync(RecipeId.Create(request.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                return Domain.Common.Errors.RecipeErrors.RecipeStep.RecipeNotFound;
            }

            recipe.DeleteIngredient(RecipeSectionId.Create(request.RecipeSectionId), ProductId.Create(request.IngredientId.ToString()));
            await _recipeRepository.UpdateAsync(recipe);

            return Unit.Value;
        }
    }
}