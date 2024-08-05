namespace Menu.Infrastructure.Messaging;

    using MassTransit;
    using SharedCore.Contracts.Consumers.Recipe;

public class RecipeClient
    {
        private readonly IRequestClient<RecipeConsumerRequest> _client;

        public RecipeClient(IRequestClient<RecipeConsumerRequest> client)
        {
            _client = client;
        }

        public async Task<List<RecipeConsumerResponse>> GetRecipesForUserAsync(RecipeConsumerRequest request)
    {
        var req = _client.Create(request);
        var response = await req.GetResponse<List<RecipeConsumerResponse>>();

        return response.Message;
    }
    }
