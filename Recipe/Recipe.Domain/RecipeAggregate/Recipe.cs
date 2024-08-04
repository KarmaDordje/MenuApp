namespace Recipe.Domain.RecipeAggregate;

using global::Recipe.Domain.Common.Models;
using global::Recipe.Domain.IngredientAggregate.ValueObjects;
using global::Recipe.Domain.RecipeAggregate.Entities;
using global::Recipe.Domain.RecipeAggregate.ValueObjects;
using global::Recipe.Domain.ValueObjects;

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
            string.Empty,
            0,
            string.Empty,
            string.Empty,
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

    public void DeleteIngredient(RecipeSectionId sectionId, ProductId ingredientId)
    {
        var section = _recipeSections.FirstOrDefault(x => x.Id == sectionId);

        if (section is null)
        {
            throw new InvalidOperationException("Section not found");
        }

        var ingredient = section.Ingredients.FirstOrDefault(x => x.Id == ingredientId);

        if (ingredient is null)
        {
            throw new InvalidOperationException("Ingredient not found");
        }

        section.DeleteIngredient(ingredient);
    }

    public void DeleteRecipeSection(RecipeSectionId sectionId)
    {
        var section = _recipeSections.FirstOrDefault(x => x.Id == sectionId);

        if (section is null)
        {
            throw new InvalidOperationException("Section not found");
        }

        _recipeSections.Remove(section);
    }

    public void DeleteRecipeStep(RecipeStepId stepId)
    {
        var step = _recipeSteps.FirstOrDefault(x => x.Id == stepId);

        if (step is null)
        {
            throw new InvalidOperationException("Step not found");
        }

        _recipeSteps.Remove(step);
    }

#pragma warning disable CS8618
    private Recipe()
    {
    }
#pragma warning restore CS8618

}