using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(string ingredientId, decimal quantity)
        {
            IngredientId = IngredientId.Create(ingredientId);
            Quantity = quantity;
        }

        public IngredientId IngredientId { get; set; }
        public decimal Quantity { get; set; }

        public static RecipeIngredient Create(string ingredientId, decimal quantity)
        {
            return new RecipeIngredient(ingredientId, quantity);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return IngredientId;
            yield return Quantity;
        }

        #pragma warning disable CS8618
        private RecipeIngredient()
        {
        }
        #pragma warning restore CS8618

    }

}