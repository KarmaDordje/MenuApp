using Recipe.Domain.Common.Models;
using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.RecipeAggregate.Entities;
using Recipe.Domain.RecipeAggregate.Events;
using Recipe.Domain.RecipeAggregate.ValueObjects;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.RecipeAggregate;

public sealed class Recipe : AggregateRoot<RecipeId, Guid>
{
    private readonly List<RecipeSection> _recipeSections = new ();
    private readonly List<RecipeStep> _recipeSteps = new ();

    public string Name { get; private set; }
    public string UserId { get; private set; }
    public string Description { get; private set; }
    public float AvarageRating { get; set; }
    public string ImageUrl { get; private set; }
    public string VideoUrl { get; private set; }
    public IReadOnlyList<RecipeSection> RecipeSections => _recipeSections.AsReadOnly();
    public IReadOnlyList<RecipeStep> RecipeSteps => _recipeSteps.AsReadOnly();
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
        List<RecipeSection> sections,
        List<RecipeStep> steps)
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
        _recipeSections = sections;
        _recipeSteps = steps;
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
    public void AddRecipeSection(RecipeSection section)
    {
        _recipeSections.Add(section);
    }

    public void AddIngredient(RecipeSectionId sectionId, RecipeIngredient ingredient)
    {
        var section = _recipeSections.FirstOrDefault(x => x.Id == sectionId);

        if (section is null)
        {
            section = RecipeSection.Create("Recipe Section", new ());
            section.AddIngredient(ingredient);
            _recipeSections.Add(section);
        }

        section.AddIngredient(ingredient);
    }

    public void AddStep(RecipeStep step)
    {
        _recipeSteps.Add(step);
    }

#pragma warning disable CS8618
    private Recipe()
    {
    }
#pragma warning restore CS8618

}