namespace Recipe.Contracts.Recipes
{
    using Recipe.Domain.Common.Shared;
    public record CreateRecipeRequest(
        string Name,
        string UserId,
        string? SectionName,
        Category Category);
}