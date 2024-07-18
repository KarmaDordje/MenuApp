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
            string title,
            List<RecipeIngredient> ingredients)
            : base(RecipeSectionId.CreateUnique())
        {
            Title = title;
            _ingredients = ingredients;
        }

        public static RecipeSection Create(
            string title,
            List<RecipeIngredient> ingredients)
        {
            var recipeSection = new RecipeSection(
                title,
                ingredients);
            return recipeSection;
        }

        public void AddIngredient(RecipeIngredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        #pragma warning disable CS8618
        private RecipeSection()
        {
        }
        #pragma warning restore CS8618
    }
}