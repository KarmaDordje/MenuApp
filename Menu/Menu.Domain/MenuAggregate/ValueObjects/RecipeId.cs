namespace Recipe.Domain.ValueObjects
{
    using global::Menu.Domain.Common.Models;
    public sealed class RecipeId : AggregateRootId<Guid>
    {

        private RecipeId(Guid value) : base(value)
        {
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
