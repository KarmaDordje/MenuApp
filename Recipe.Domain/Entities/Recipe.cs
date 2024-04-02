using Recipe.Domain.Common.Models;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.Entities;

public sealed class Recipe : AggregateRoot<RecipeId>
{
    private readonly List<Ingredient> _ingredients = new ();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float AvarageRating { get; set; }
    public string Image { get; private set; }
    public string VideoUrl { get; private set; }
    public List<string>? Steps { get; private set; }
    public IReadOnlyList<Ingredient> Ingredients => _ingredients.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Recipe(
        RecipeId recipeId,
        string name,
        string description,
        float avarageRating,
        string image,
        string videoUrl,
        List<string> steps,
        List<Ingredient> ingredients,
        DateTime createdAt,
        DateTime updatedAt)
        : base(recipeId)
    {
        Name = name;
        Description = description;
        AvarageRating = avarageRating;
        Image = image;
        VideoUrl = videoUrl;
        Steps = steps;
        _ingredients = ingredients;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Recipe Create(
        string name,
        string description,
        float avarageRating,
        string image,
        string videoUrl,
        List<string> steps,
        List<Ingredient> ingredients,
        DateTime createdAt,
        DateTime updatedAt)
    {
        return new Recipe(
            RecipeId.CreateUnique(),
            name,
            description,
            avarageRating,
            image,
            videoUrl,
            steps,
            ingredients,
            createdAt,
            updatedAt);
    }

}