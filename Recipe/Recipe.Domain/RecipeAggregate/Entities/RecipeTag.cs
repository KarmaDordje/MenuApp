namespace Recipe.Domain.RecipeAggregate.Entities
{
    using global:: Recipe.Domain.Common.Models;
    using global::Recipe.Domain.ValueObjects;
    public class RecipeTag : Entity<TagId>
    {
        public string Name { get; private set; }
        private RecipeTag(string name)
        : base(TagId.CreateUnique())
        {
            Name = name;
        }

        public static RecipeTag Create(string name)
        {
        // TODO: enforce invariants
            return new RecipeTag(name);
        }

#pragma warning disable CS8618
        private RecipeTag()
        {
        }
#pragma warning restore CS8618
    }
}