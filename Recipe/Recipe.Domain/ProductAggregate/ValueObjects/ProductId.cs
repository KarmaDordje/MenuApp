namespace Recipe.Domain.IngredientAggregate.ValueObjects
{
    using ErrorOr;
    using Recipe.Domain.Common.Models;

    public class ProductId : AggregateRootId<string>
    {
         private ProductId(string value)
            : base(value)
        {
        }

         public static ProductId Create(string ingredientId)
        {
        // TODO: enforce invariants
            return new ProductId(ingredientId);
        }

         public static ProductId CreateUnique()
        {
        // TODO: enforce invariants
        return new ProductId(Guid.NewGuid().ToString());
        }
    }
}