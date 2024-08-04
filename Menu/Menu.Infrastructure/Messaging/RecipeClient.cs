namespace Menu.Infrastructure.Messaging;

    using MassTransit;
    using Menu.Contracts.Recipies.Consumers;

public class RecipeClient
    {
        private readonly IRequestClient<RecipeConsumerRequest> _client;

        public RecipeClient(IRequestClient<RecipeConsumerRequest> client)
        {
            _client = client;
        }

        public async Task<RecipeConsumerResponse> GetRecipesForUserAsync(RecipeConsumerRequest request)
    {
        var response = await _client.GetResponse<RecipeConsumerResponse>(request);

        return response.Message;
    }
    }
