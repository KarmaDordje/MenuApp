using Recipe.Application.ApiModels;
using Recipe.Application.Interfaces;
using Recipe.Domain.Entities;
using Recipe.Infrastructure.Common;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.External
{
    public class NutritionApiClient : GenericApiClient, INutritionClient
    {

        public NutritionApiClient(string baseUrl, string apiKey, string headerName)
            : base(baseUrl, apiKey, headerName) { }

        /// <summary>
        /// Returns nutriton infromation about product
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task<NutritionResponse> GetProductNutrition(string productName)
        {
            var result = await Request<List<NutritionResponse>>(() => new RestRequest($"?query={productName}"));

            return result.First();
        }

        // private Ingredient ConvertToPerGramNutritionData(NutritionResponse response)
        // {
        //    var result = new Ingredient(response)
        //    {
        //        Calories = response.CaloriesG / response.ServingSize,
        //        Cholesterol = response.CholesterolMg / response.ServingSize,
        //        FatSaturated = response.FatSaturatedG / response.ServingSize,
        //        FatTotal = response.FatTotalG / response.ServingSize,
        //        Name = response.Name,
        //        Potassium = response.PotassiumMg / response.ServingSize,
        //        Protein = response.ProteinG / response.ServingSize,
        //        MeasuresType = (int)MeasureType.Gramms,
        //        Sodium = response.SodiumMg / response.ServingSize,
        //    };
        //    return result;
        // }

    }
}
