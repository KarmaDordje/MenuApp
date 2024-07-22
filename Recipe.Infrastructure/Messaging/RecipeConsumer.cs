namespace Recipe.Infrastructure.Messaging
{
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Contracts.Recipes.ConsumerContracts;

    public class RecipeConsumer : IConsumer<RecipeConsumerRequest>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger<RecipeConsumer> _logger;

        public RecipeConsumer(
            IRecipeRepository recipeRepository,
            ILogger<RecipeConsumer> logger)
        {
            _recipeRepository = recipeRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RecipeConsumerRequest> context)
        {
            var recipe = await _recipeRepository.GetAllUserRecipes(context.Message.UserId);
            _logger.LogInformation($"Recipe received for UserId: {context.Message.UserId}");

            await context.RespondAsync(new RecipeConsumerResponse { Recipe = recipe.ToList() });
        }
    }
}