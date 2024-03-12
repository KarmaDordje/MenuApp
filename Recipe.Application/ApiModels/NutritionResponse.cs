using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recipe.Application.ApiModels
{
    public class NutritionResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("calories")]
        public decimal CaloriesG { get; set; }

        [JsonPropertyName("serving_size_g")]
        public decimal ServingSize { get; set; }

        [JsonPropertyName("fat_total_g")]
        public decimal FatTotalG { get; set; }

        [JsonPropertyName("fat_saturated_g")]
        public decimal FatSaturatedG { get; set; }

        [JsonPropertyName("protein_g")]
        public decimal ProteinG { get; set; }

        [JsonPropertyName("sodium_mg")]
        public decimal SodiumMg { get; set; }

        [JsonPropertyName("potassium_mg")]
        public decimal PotassiumMg { get; set; }

        [JsonPropertyName("cholesterol_mg")]
        public decimal CholesterolMg { get; set; }

        [JsonPropertyName("carbohydrates_total_g")]
        public decimal CarbohydratesTotalG { get; set; }

        [JsonPropertyName("fiber_g")]
        public decimal FiberG { get; set; }

        [JsonPropertyName("SugarG")]
        public decimal SugarG { get; set; }
    }
}
