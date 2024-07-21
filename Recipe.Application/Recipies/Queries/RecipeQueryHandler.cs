namespace Recipe.Application.Recipes.Queries
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using MediatR;

    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Application.Interfaces.Persistence;
    using Recipe.Contracts.Recipes;
    using Recipe.Domain.ValueObjects;


    public class RecipeQueryHandler : IRequestHandler<RecipeQuery, ErrorOr<RecipeResponse>>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public RecipeQueryHandler(
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<ErrorOr<RecipeResponse>> Handle(RecipeQuery request, CancellationToken cancellationToken)
        {
            var recipeId = RecipeId.Create(request.RecipeId);

            if (await _recipeRepository.GetAsync(recipeId) is not Domain.RecipeAggregate.Recipe recipe)
            {
                return Domain.Common.Errors.RecipeErrors.RecipeStep.RecipeNotFound;
            }

            List<RecipeSectionResponse> recipeSections = new List<RecipeSectionResponse>();
            List<RecipeStepResponse> recipeSteps = new List<RecipeStepResponse>();

            foreach (var section in recipe.RecipeSections)
            {
                var ingredientIds = section.Ingredients
                    .Select(i => i.Id)
                    .ToList();

                var ingredients = await _ingredientRepository.GetByIds(ingredientIds);
                RecipeSectionResponse dtoSection = new RecipeSectionResponse(
                    section.Id.Value.ToString(),
                    section.Title,
                    ingredients
                        .Select(i => new RecipeIngredientResponse(
                            i.Id.Value.ToString(),
                            i.PolishName,
                            i.Calories,
                            i.Cholesterol,
                            i.FatSaturated,
                            i.FatTotal,
                            i.Potassium,
                            i.Protein,
                            i.Sodium,
                            i.Sugar,
                            section.Ingredients.First(ing => ing.Id == i.Id).Quantity.ToString(),
                            "g"))
                        .ToList());

                recipeSections.Add(dtoSection);
            }

            foreach (var step in recipe.RecipeSteps)
            {
                RecipeStepResponse dtoStep = new RecipeStepResponse(
                    step.Id.Value.ToString(),
                    step.Order,
                    step.Name,
                    step.ImgUrl,
                    step.VideoUrl);
                recipeSteps.Add(dtoStep);
            }

            RecipeResponse result = new RecipeResponse(
                recipe.Id.Value.ToString(),
                recipe.Name,
                recipe.Description,
                recipe.AvarageRating,
                recipe.ImageUrl,
                recipe.VideoUrl,
                recipeSections,
                recipeSteps,
                recipe.CreatedAt,
                recipe.UpdatedAt);

            return result;
        }
    }
}