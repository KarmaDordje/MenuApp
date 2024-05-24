using ErrorOr;
using MediatR;
using Recipe.Application.Common.Interfaces.Persistence;

using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<Guid>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = Domain.RecipeAggregate.Recipe.Create(
                request.Name,
                request.UserId);

            _recipeRepository.AddAsync(recipe);
            return recipe.Id.Value;
        }
    }
}