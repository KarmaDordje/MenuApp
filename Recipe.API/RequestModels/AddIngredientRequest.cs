namespace Recipe.API.RequestModels
{
    using System.ComponentModel.DataAnnotations;


    public class AddIngredientRequest
    {
        public string IngredientName { get; set; }
        public decimal Quantity { get; set; }
    }
}