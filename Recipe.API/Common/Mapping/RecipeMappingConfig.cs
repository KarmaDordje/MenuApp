namespace Recipe.API.Common.Mapping
{
    using Mapster;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    using Recipe.Contracts.Recipes;

   public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateRecipeRequest, CreateRecipeCommand>();
    }
}
}