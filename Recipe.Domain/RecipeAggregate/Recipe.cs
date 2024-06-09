using Recipe.Domain.Common.Models;
using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.RecipeAggregate.Entities;
using Recipe.Domain.RecipeAggregate.Events;
using Recipe.Domain.ValueObjects;


namespace Recipe.Domain.RecipeAggregate;

public sealed class Recipe : AggregateRoot<RecipeId, Guid>
{
    private readonly List<RecipeIngredient> _ingredients = new ();
    private readonly List<RecipeStep> _recipeSteps = new ();
    public string Name { get; private set; }
    public string UserId { get; private set; }
    public string Description { get; private set; }
    public float AvarageRating { get; set; }
    public string ImageUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public IReadOnlyList<RecipeStep> RecipeSteps => _recipeSteps.AsReadOnly();
    public IReadOnlyList<RecipeIngredient> Ingredients => _ingredients.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Recipe(
        RecipeId recipeId,
        string name,
        string userId,
        string description,
        float avarageRating,
        string image,
        string videoUrl,
        DateTime createdAt,
        DateTime updatedAt,
        List<RecipeStep> steps,
        List<RecipeIngredient> ingredients)
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
        string userId)
    {
        var recipe = new Recipe(
            RecipeId.CreateUnique(),
            name,
            userId,
            "",
            0,
            "",
            "",
            DateTime.Now.ToUniversalTime(),
            DateTime.Now.ToUniversalTime(),
            new (),
            new ());
        return recipe;
    }

    public void AddIngredient(RecipeIngredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    public void AddStep(RecipeStep step)
    {
        _recipeSteps.Add(step);
    }

    // public static Recipe Create(
    //     string name,
    //     string userId,
    //     string description,
    //     float avarageRating,
    //     string image,
    //     string videoUrl,
    //     DateTime createdAt,
    //     DateTime updatedAt,
    //     List<RecipeStep>? steps = null,
    //     List<RecipeIngredient>? ingredients = null)
    // {
    //     var recipe = new Recipe(
    //         RecipeId.CreateUnique(),
    //         name,
    //         userId,
    //         description,
    //         avarageRating,
    //         image,
    //         videoUrl,
    //         createdAt,
    //         updatedAt,
    //         steps ?? new (),
    //         ingredients ?? new ());
    //     recipe.AddDomainEvent(new RecipeCreated(recipe));
    //     return recipe;
    // }

#pragma warning disable CS8618
    private Recipe()
    {
    }
#pragma warning restore CS8618

}