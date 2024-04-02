namespace Recipe.Contracts.Recipes
{
    public record CreareRecipeResponse(CreateRecipeStatus Status);

    /// <summary>
    /// Represents the status of creating a recipe.
    /// </summary>
    public enum CreateRecipeStatus
    {
        /// <summary>
        /// The recipe was created successfully.
        /// </summary>
        Success = 0,

        /// <summary>
        /// An error occurred while creating the recipe.
        /// </summary>
        Error = 1
    }
}