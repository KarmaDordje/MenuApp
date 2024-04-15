using ErrorOr;

using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class IngredientId : AggregateRootId<string>
    {
         private IngredientId(string value)
            : base(value)
        {
        }

        public static IngredientId Create(string hostId)
        {
        // TODO: enforce invariants
            return new IngredientId(hostId);
        }
         public static IngredientId CreateUnique()
        {
        // TODO: enforce invariants
        return new IngredientId(Guid.NewGuid().ToString());
        }
    }
}