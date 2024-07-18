using System.Text.Json.Serialization;

namespace Recipe.Application.ApiModels;

public class NutritionResponse
{
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }
}