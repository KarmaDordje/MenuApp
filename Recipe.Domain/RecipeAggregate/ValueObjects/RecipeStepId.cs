using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class RecipeStepId : ValueObject
    {
        public Guid Value { get; private set; }

        private RecipeStepId(Guid value)
        {
            Value = value;
        }

        public static RecipeStepId CreateUnique()
        {
            return new RecipeStepId(Guid.NewGuid());
        }

        public static RecipeStepId Create(Guid value)
        {
            return new RecipeStepId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}