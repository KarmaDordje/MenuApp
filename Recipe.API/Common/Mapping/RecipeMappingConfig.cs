namespace Recipe.API.Common.Mapping
{
    using Mapster;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Contracts.Recipes;

   public class RecipeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRecipeRequest, int UserId), CreateRecipeCommand>()
            .Map(dest => dest.UserId, src => src.UserId);

        config.NewConfig<Domain.Entities.Recipe, CreateRecipeResponse>()
            .Map(dest => dest.RecipeId, src => src.Id.Value);
        config.NewConfig<Domain.Entities.Ingredient, IngredientResponse>()
            .Map(dest => dest.IngredientId, src => src.Id.Value);
            
    }
}
}