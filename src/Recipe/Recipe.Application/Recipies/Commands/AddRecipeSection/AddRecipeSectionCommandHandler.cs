namespace Recipe.Application.Recipes.Commands.AddRecipeSection
{
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using MediatR;

    using Recipe.Application.Common.Interfaces.Persistence;

    using Recipe.Contracts.Recipes;
    using Recipe.Domain.RecipeAggregate.Entities;

    using Recipe.Domain.ValueObjects;


    public class AddRecipeSectionCommandHandler : IRequestHandler<AddRecipeSectionCommand, ErrorOr<AddRecipeSectionResponse>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public AddRecipeSectionCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<AddRecipeSectionResponse>> Handle(AddRecipeSectionCommand request, CancellationToken cancellationToken)
        {
            if (await _recipeRepository.GetAsync(RecipeId.Create(request.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                throw new InvalidOperationException($"Recipe has invalid recipe id (recipe id: {request.RecipeId}).");
            }

            var recipeSection = RecipeSection.Create(request.Title, new ());
            recipe.AddRecipeSection(recipeSection);
            await _recipeRepository.UpdateAsync(recipe);
            return new AddRecipeSectionResponse(recipeSection.Id.Value.ToString());
        }
    }
}