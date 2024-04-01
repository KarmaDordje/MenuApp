using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class IngredientId : ValueObject
    {
        public Guid Value { get; private set; }

        private IngredientId(Guid value)
        {
            Value = value;
        }

        public static IngredientId CreateUnique()
        {
            return new IngredientId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}