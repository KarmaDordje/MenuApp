using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.ValueObjects;

namespace Recipe.Application.UnitTests.TestUnits.Constants;

public static partial class Constatnts
{
    public static class Ingredient
    {
        public static readonly IngredientId IngredientId = IngredientId.Create("Ingredient Id");

    }
}