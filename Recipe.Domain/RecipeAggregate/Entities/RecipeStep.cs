namespace Recipe.Domain.RecipeAggregate.Entities
{
    using Domain.Common.Models;
    using Domain.ValueObjects;
    public class RecipeStep : Entity<RecipeStepId>
    {
        public int Order { get; private set; }
        public string Name { get; private set; }
        private RecipeStep(int order, string name)
        : base(RecipeStepId.CreateUnique())
    {
        Name = name;
        Order = order;
    }

        public static RecipeStep Create(int order, string name)
    {
        // TODO: enforce invariants
        return new RecipeStep(order, name);
    }

#pragma warning disable CS8618
        private RecipeStep()
    {
    }
#pragma warning restore CS8618
    }
}