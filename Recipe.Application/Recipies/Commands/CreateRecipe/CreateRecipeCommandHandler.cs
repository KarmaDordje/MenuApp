using System.Data;

using ErrorOr;

using MediatR;

using Recipe.Application.Common.Interfaces.Persistence;
using Recipe.Domain.Entities;

using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<Domain.Entities.Recipe>>
    {
        private readonly IRecipeRepository _recipeRepository;

        public CreateRecipeCommandHandler(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<ErrorOr<Domain.Entities.Recipe>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var recipe = Domain.Entities.Recipe.Create(
                request.Name,
                request.UserId,
                request.Description,
                0,
                request.ImageUrl,
                request.VideoUrl,
                DateTime.Now.ToUniversalTime(),
                DateTime.Now.ToUniversalTime(),
                request.RecipeSteps.ConvertAll(x => Domain.Entities.RecipeStep.Create(x.Order, x.Name)),
                request.Ingredients.ConvertAll(x => RecipeIngredient.Create(x.IngredientId, x.Quantity)));

            _recipeRepository.AddAsync(recipe);
            return recipe;
        }
    }
}