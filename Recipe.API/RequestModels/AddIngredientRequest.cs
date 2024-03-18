using System.ComponentModel.DataAnnotations;

namespace Recipe.API.RequestModels
{
    public class AddIngredientRequest
    {   
        [Required]
        [MinLength(3)]
        public string IngredientName { get; set; }
        
        [Required]
        [Range(0.1, 1000)]
        public decimal Quantity { get; set; }
    }
}