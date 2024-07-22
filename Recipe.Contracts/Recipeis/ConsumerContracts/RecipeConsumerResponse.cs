namespace Recipe.Contracts.Recipes.ConsumerContracts
{
    using Recipe.Domain.ValueObjects;
    public class RecipeConsumerResponse
    {
        public List<Domain.RecipeAggregate.Recipe> Recipe { get; set; }
    }
}