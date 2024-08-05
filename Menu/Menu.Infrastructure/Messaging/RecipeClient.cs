namespace Menu.Infrastructure.Messaging;

    using MassTransit;
    using Menu.Contracts.Recipies.Consumers;

public class RecipeClient
    {
        private readonly IRequestClient<global::Recipe.Contracts.Recipes.ConsumerContracts.RecipeConsumerRequest> _client;

        public RecipeClient(IRequestClient<global::Recipe.Contracts.Recipes.ConsumerContracts.RecipeConsumerRequest> client)
        {
            _client = client;
        }

        public async Task<global::Recipe.Contracts.Recipes.ConsumerContracts.RecipeConsumerResponse> GetRecipesForUserAsync(global::Recipe.Contracts.Recipes.ConsumerContracts.RecipeConsumerRequest request)
    {
        var req = _client.Create(request);
        var response = await req.GetResponse<global::Recipe.Contracts.Recipes.ConsumerContracts.RecipeConsumerResponse>();

        return response.Message;
    }
    }
