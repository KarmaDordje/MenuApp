namespace Recipe.Infrastructure.External
{
    using Microsoft.Extensions.Logging;


    using Recipe.Application.ApiModels;
    using Recipe.Application.Interfaces;
    using RestSharp;

    public class NutritionApiClient : GenericApiClient, INutritionClient
    {
        private readonly ILogger<NutritionApiClient> _logger;
        public NutritionApiClient(string baseUrl, string apiKey, string headerName)
            : base(baseUrl, apiKey, headerName)
        {
            _logger = new LoggerFactory().CreateLogger<NutritionApiClient>();
            _logger.LogInformation($"NUTRITION API CLIENT BASE URL: {baseUrl}");
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
            _logger.LogInformation($"Nutrition for {result.Items.FirstOrDefault().Name} retrieved");

            return result.Items.FirstOrDefault();
        }
    }
}
