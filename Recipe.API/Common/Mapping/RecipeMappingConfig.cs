namespace Recipe.API.Common.Mapping
{
    using Mapster;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Contracts.Ingredients;
    using Recipe.Contracts.Recipes;
    using Recipe.Domain.IngredientAggregate;

    public class RecipeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRecipeRequest, int UserId), CreateRecipeCommand>()
            .Map(dest => dest.UserId, src => src.UserId);

        config.NewConfig<Domain.RecipeAggregate.Recipe, CreateRecipeResponse>()
            .Map(dest => dest.RecipeId, src => src.Id.Value);
        config.NewConfig<Product, CreateProductResponse>()
            .Map(dest => dest.IngredientId, src => src.Id.Value);

    }
}
}