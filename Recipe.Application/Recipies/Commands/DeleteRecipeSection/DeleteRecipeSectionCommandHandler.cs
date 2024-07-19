namespace Recipe.Application.Recipes.Commands.DeleteRecipeSection
{
    using System.Threading;
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Application.Recipes.Commands.DeleteIngredient;
    using Recipe.Domain.RecipeAggregate.ValueObjects;

    using Recipe.Domain.ValueObjects;

    public class DeleteRecipeSectionCommandHandler : IRequestHandler<DeleteRecipeSectionCommand, ErrorOr<Unit>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public DeleteRecipeSectionCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteRecipeSectionCommand request, CancellationToken cancellationToken)
        {
            if (await _recipeRepository.GetAsync(RecipeId.Create(request.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                return Domain.Common.Errors.RecipeErrors.RecipeStep.RecipeNotFound;
            }

            recipe.DeleteRecipeSection(RecipeSectionId.Create(request.RecipeSectionId));
            await _recipeRepository.UpdateAsync(recipe);

            return Unit.Value;
        }
    }
}