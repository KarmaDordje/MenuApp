namespace Recipe.Domain.RecipeAggregate.Entities
{
    using System;
    using System.Collections.Generic;
    using global::Recipe.Domain.Common;
    using global::Recipe.Domain.Common.Models;
    using global::Recipe.Domain.RecipeAggregate.ValueObjects;
    using global::Recipe.Domain.ValueObjects;

    public class RecipeSection : Entity<RecipeSectionId>
    {
        public string Title { get; private set; }
        private readonly List<RecipeIngredient> _ingredients = new ();
        public IReadOnlyList<RecipeIngredient> Ingredients => _ingredients.AsReadOnly();

        private RecipeSection(
            RecipeSectionId recipeSectionId,
            string title,
            List<RecipeIngredient> ingredients)
            : base(recipeSectionId)
        {
            Title = title;
            _ingredients = ingredients;
        }

        public static RecipeSection Create(
            string title,
            List<RecipeIngredient> ingredients)
        {
            var recipeSection = new RecipeSection(
                RecipeSectionId.CreateUnique(),
                title,
                ingredients ?? new ());
            return recipeSection;
        }

        public void AddIngredient(RecipeIngredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public void DeleteIngredient(RecipeIngredient ingredient)
        {
            _ingredients.Remove(ingredient);
        }

        #pragma warning disable CS8618
        private RecipeSection()
        {
        }
        #pragma warning restore CS8618
    }
}