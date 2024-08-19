namespace Recipe.Contracts.Recipes.GetRecipeResponse;

    public class RecipeSectionResponse
    {
        public Guid RecipeSectionId { get; set; }
        public string Title { get; set; }
        public Guid RecipeId { get; set; }
        public List<RecipeIngredientResponse> Ingredients { get; set; }
    }