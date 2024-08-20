namespace Recipe.Contracts.Recipes
{   

    using Recipe.Contracts.Recipes.GetRecipeResponse;

    public class RecipeGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float AvarageRating { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public List<RecipeSectionResponse> RecipeSections { get; set; }
        public List<RecipeStepResponse> RecipeSteps { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}