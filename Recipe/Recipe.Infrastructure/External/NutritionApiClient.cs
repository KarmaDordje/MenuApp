namespace Recipe.Infrastructure.External
{
    using ErrorOr;

    using Microsoft.Extensions.Logging;


    using Recipe.Application.ApiModels;
    using Recipe.Application.Interfaces;
    using RestSharp;

    public class NutritionApiClient : GenericApiClient, INutritionClient
    {
        private readonly ILogger<NutritionApiClient> _logger;
        public NutritionApiClient(string baseUrl, string apiKey, string headerName, ILogger<NutritionApiClient> logger)
            : base(baseUrl, apiKey, headerName) 
            {
                _logger = logger;
            }

        /// <summary>
        /// Returns nutriton infromation about product
        /// </summary>
        /// <summary>
        /// Retrieves the nutrition information for a given product.
        /// </summary>
        /// <param name="productName">The name of the product.</param>
        /// <returns>The nutrition response for the product.</returns>
        public async Task<Item> GetProductNutrition(string productName)
        {
            var result = await Request<NutritionResponse>(() => new RestRequest($"?query={productName}"));
            _logger.LogInformation($"NutritionApiClient.GetProductNutrition: {result}");
            return result.Items.FirstOrDefault();
        }
    }
}
