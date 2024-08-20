namespace Recipe.Contracts.Recipes.GetRecipeResponse;

   public class RecipeStepResponse
    {   
        public Guid RecipeId { get; set; }
        public Guid RecipeStepId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }