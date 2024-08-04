namespace Recipe.Contracts.Recipes.ConsumerContracts
{
    using Recipe.Domain.ValueObjects;
    public class RecipeConsumerResponse
    {
        public List<string> Recipe { get; set; }
    }
}