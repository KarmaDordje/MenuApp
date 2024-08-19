namespace Recipe.Contracts.Recipes.GetRecipeResponse;

    public class RecipeIngredientResponse
    {   
        public Guid RecipeId { get; set; }
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