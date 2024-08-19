namespace Recipe.Contracts.Recipes
{
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
    
    public class RecipeResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float AvarageRating { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class RecipeSectionResponse
    {
        public Guid RecipeSectionId { get; set; }
        public string Title { get; set; }
        public List<RecipeIngredientResponse> Ingredients { get; set; }
    }

    public class RecipeIngredientResponse
    {   
        public string RecipeIngredientId { get; set; }
        public Guid RecipeSectionId { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public string PolishName { get; set; }
        public decimal Calories { get; set; }
        public decimal Cholesterol { get; set; }
        public decimal FatSaturated { get; set; }
        public decimal FatTotal { get; set; }
        public decimal Potassium { get; set; }
        public decimal Protein { get; set; }
        public decimal Sodium { get; set; }
        public decimal Sugar { get; set; }
        public string Unit { get; set; }
    }
    
    public class  RecipeStepResponse
    {
        public Guid RecipeStepId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
    }

}