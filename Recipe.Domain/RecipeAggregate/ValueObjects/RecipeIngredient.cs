namespace Recipe.Domain.ValueObjects
{
    using Recipe.Domain.Common.Models;
    using Recipe.Domain.IngredientAggregate.ValueObjects;

    public class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(string ingredientId, decimal quantity)
        {
            Id = ProductId.Create(ingredientId);
            Quantity = quantity;
        }

        public ProductId Id { get; set; }
        public decimal Quantity { get; set; }

        public static RecipeIngredient Create(string ingredientId, decimal quantity)
        {
            return new RecipeIngredient(ingredientId, quantity);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Quantity;
        }

        #pragma warning disable CS8618
        private RecipeIngredient()
        {
        }
        #pragma warning restore CS8618

    }

}