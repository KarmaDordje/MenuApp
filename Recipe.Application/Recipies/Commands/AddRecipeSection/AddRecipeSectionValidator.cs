namespace Recipe.Application.Recipes.Commands.AddRecipeSection

{
    using FluentValidation;

    public class AddRecipeSectionValidator : AbstractValidator<AddRecipeSectionCommand>
    {
        public AddRecipeSectionValidator()
        {
            RuleFor(x => x.RecipeId).NotEmpty();
            RuleFor(x => x.Title)
            .MinimumLength(0)
            .MaximumLength(100);
        }
    }
}