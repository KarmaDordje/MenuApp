namespace Recipe.Domain.ValueObjects
{
    using global::Menu.Domain.Common.Models;
    public class RecipeId : ValueObject
    {
        public Guid Value { get; private set; }

        public RecipeId(Guid value)
        {
            Value = value;
        }

        public static RecipeId CreateUnique()
        {
            return new RecipeId(Guid.NewGuid());
        }

        public static RecipeId Create(Guid value)
        {
            return new RecipeId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
