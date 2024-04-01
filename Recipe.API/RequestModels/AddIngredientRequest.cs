using System.ComponentModel.DataAnnotations;

namespace Recipe.API.RequestModels
{
    public class AddIngredientRequest
    {

        public string IngredientName { get; set; }

        public decimal Quantity { get; set; }
    }
}