namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    using ErrorOr;
    using MediatR;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Contracts.Recipes;

    using Recipe.Domain.RecipeAggregate.Entities;

    using Recipe.Domain.ValueObjects;

    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<CreateRecipeResponse>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<CreateRecipeResponse>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = Domain.RecipeAggregate.Recipe.Create(
                request.Name,
                request.UserId);
            var recipeSection = RecipeSection.Create(request.SectionName ?? string.Empty, new List<RecipeIngredient>());
            recipe.AddRecipeSection(recipeSection);
            await _recipeRepository.AddAsync(recipe);
            return new CreateRecipeResponse(recipe.Id.Value, recipeSection.Id.Value);
        }
    }
}