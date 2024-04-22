using ErrorOr;

using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using RestSharp;

namespace Recipe.Infrastructure.External
{
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
        public async Task<NutritionResponse> GetProductNutrition(string productName)
        {
            var result = await Request<List<NutritionResponse>>(() => new RestRequest($"?query={productName}"));

            return result.First();
        }
    }
}
