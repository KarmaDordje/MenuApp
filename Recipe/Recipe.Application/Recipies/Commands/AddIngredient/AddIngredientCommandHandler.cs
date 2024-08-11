namespace Recipe.Application.Recipes.Commands.AddIngredientCommandHandler
{
    using AutoMapper;
    using ErrorOr;
    using MediatR;

    using Microsoft.Extensions.Logging;


    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Application.Interfaces;
    using Recipe.Application.Interfaces.Persistence;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Domain.Dtos;
    using Recipe.Domain.RecipeAggregate.ValueObjects;

    using Recipe.Domain.ValueObjects;

    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, ErrorOr<ProductDTO>>
    {
        private readonly IMapper _mapper;
        private readonly INutritionCalculationService _nutritionCalculationService;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger<AddIngredientCommandHandler> _logger;

        public AddIngredientCommandHandler(
            IMapper mapper,
            INutritionCalculationService nutritionCalculationService,
            IIngredientRepository ingredientRepository,
            IRecipeRepository recipeRepository,
            ILogger<AddIngredientCommandHandler> logger)
        {
            _mapper = mapper;
            _nutritionCalculationService = nutritionCalculationService;
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _logger = logger;
        }

        public async Task<ErrorOr<ProductDTO>> Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Adding ingredient to recipe: {command.RecipeId}");
            var ingredient = await _ingredientRepository.GetAsyncByIngredientName(command.IngredientName);

            if (ingredient is null)
            {
                try
                {
                    ingredient = await _nutritionCalculationService.CalculateNutritionPerGramm(command.IngredientName);
                    await _ingredientRepository.AddAsync(ingredient);
                }
                catch (Exception e)
                {
                    if (e.Message == "Sequence contains no elements")
                    {
                        return Recipe.Domain.Common.Errors.IngredientErrors.IngredientNotFound;
                    }
                }
            }

            if (await _recipeRepository.GetAsync(RecipeId.Create(command.RecipeId)) is not Domain.RecipeAggregate.Recipe recipe)
            {
                throw new InvalidOperationException($"Recipe has invalid recipe id (menu id: {command.RecipeId}).");
            }

            _logger.LogInformation($"Adding ingredient {ingredient} to recipe {recipe.Name}.");
            var recipeIngredient = RecipeIngredient.Create(ingredient.Id.Value, command.Quantity);
            recipe.AddIngredient(RecipeSectionId.Create(command.RecipeSectionId), recipeIngredient);
            await _recipeRepository.UpdateAsync(recipe);
            ProductDTO dto = _mapper.Map<ProductDTO>(ingredient);
            dto = _nutritionCalculationService.CalculateNutritionPerPortion(ingredient, command.Quantity);
            return dto;
        }
    }
}
