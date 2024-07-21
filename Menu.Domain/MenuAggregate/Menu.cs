namespace Menu.Domain.MenuAggregate
{
    using Recipe.Domain.Common.Models;
    using Recipe.Domain.ValueObjects;

    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<RecipeId> _recipes = new List<RecipeId>();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyList<RecipeId> Recipes => _recipes.AsReadOnly();
        private Menu(
            MenuId menuId,
            string name,
            string description,
            UserId userId,
            List<RecipeId> recipes)
        {
            Name = name;
            Description = description;
            UserId = userId;
            _recipes = recipes;
        }

        public static Menu Create(
            string name,
            string description,
            UserId userId)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                userId,
                new ());
            return menu;
        }

        public void AddRecipe(RecipeId recipeId)
        {
            _recipes.Add(recipeId);
        }

        public void DeleteRecipe(RecipeId recipeId)
        {
            _recipes.Remove(recipeId);
        }

        public void FillWithRecipes(List<RecipeId> recipes)
        {
            _recipes.AddRange(recipes);
        }

        // for EF Core purposes
#pragma warning disable CS8618
        public Menu()
        {
        }
#pragma warning restore CS8618
    }
}