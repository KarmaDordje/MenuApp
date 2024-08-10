namespace Recipe.Infrastructure.External
{
    using ErrorOr;

    using Microsoft.Extensions.Logging;


    using Recipe.Application.ApiModels;
    using Recipe.Application.Interfaces;
    using RestSharp;

    public class NutritionApiClient : GenericApiClient, INutritionClient
    {
        public NutritionApiClient(string baseUrl, string apiKey, string headerName)
            : base(baseUrl, apiKey, headerName) { }

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
            System.Console.WriteLine(result);

            return result.Items.FirstOrDefault();
        }
    }
}
