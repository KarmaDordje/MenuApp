namespace Recipe.Infrastructure.Messaging
{
    using MassTransit;
    using Microsoft.Extensions.Logging;
    using Recipe.Application.Common.Interfaces.Persistence;
    using SharedCore.Contracts.Consumers.Recipe;
    using SharedCore.Enums;


    public class GetRecipeConsumer : IConsumer<RecipeConsumerRequest>
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger<GetRecipeConsumer> _logger;

        public GetRecipeConsumer(
            IRecipeRepository recipeRepository,
            ILogger<GetRecipeConsumer> logger)
        {
            _recipeRepository = recipeRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RecipeConsumerRequest> context)
        {
            var recipe = await _recipeRepository.GetAllUserRecipes(context.Message.UserId);
            _logger.LogInformation($"Recipe received for UserId: {context.Message.UserId}");
            var result = recipe.Select(r => new Recipe{
                RecipeName = r.Name,
                RecipeId = r.Id.Value.ToString(),
                AvarageRating = (decimal)r.AvarageRating,
                ImageUrl = r.ImageUrl,
                CreatedAt = r.CreatedAt,
                UserId = r.UserId,
                Category = (Category)r.Category,
            }).ToList();
 
            await context.RespondAsync(new RecipeConsumerResponse
            {
                Recipes = result
            });
        }
    }
}