namespace Recipe.Domain.ValueObjects
{
    using Recipe.Domain.Common.Models;

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