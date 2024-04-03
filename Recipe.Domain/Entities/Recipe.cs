using Recipe.Domain.Common.Models;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.Entities;

public sealed class Recipe : AggregateRoot<RecipeId, Guid>
{
    private readonly List<Ingredient> _ingredients = new ();
    private readonly List<RecipeStep> _recipeSteps = new ();
    public string Name { get; private set; }
    public int UserId { get; private set; }
    public string Description { get; private set; }
    public float AvarageRating { get; set; }
    public string ImageUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public IReadOnlyList<RecipeStep> RecipeSteps => _recipeSteps.AsReadOnly();
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Recipe(
        RecipeId recipeId,
        string name,
        int userId,
        string description,
        float avarageRating,
        string image,
        string videoUrl,
        DateTime createdAt,
        DateTime updatedAt,
        List<RecipeStep> steps,
        List<Ingredient> ingredients)
        : base(recipeId)
    {
        Name = name;
        UserId = userId;
        Description = description;
        AvarageRating = avarageRating;
        ImageUrl = image;
        VideoUrl = videoUrl;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
         _recipeSteps = steps;
        _ingredients = ingredients;
    }

    public static Recipe Create(
        string name,
        int userId,
        string description,
        float avarageRating,
        string image,
        string videoUrl,
        DateTime createdAt,
        DateTime updatedAt,
        List<RecipeStep>? steps = null,
        List<Ingredient>? ingredients = null)
    {
        return new Recipe(
            RecipeId.CreateUnique(),
            name,
            userId,
            description,
            avarageRating,
            image,
            videoUrl,
            createdAt,
            updatedAt,
            steps ?? new (),
            ingredients ?? new ());
    }
#pragma warning disable CS8618
    private Recipe()
    {
    }
#pragma warning restore CS8618

}