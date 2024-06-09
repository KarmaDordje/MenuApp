namespace Recipe.Application.UnitTests.Ingredients.Commands.TestUtils
{
    using Bogus;
    using Recipe.Application.ApiModels;
    using Recipe.Application.Ingredients.Commands.AddIngredient;

    public static class AddIngredientCommandUtils
    {
       public static AddProductCommand CreateCommand(string ingredientName = "ingredientName", int quantity = 100) =>
            new AddProductCommand(ingredientName, quantity);

       public static NutritionResponse CreateNutritionResponse()
       {
            var response = new Faker<NutritionResponse>()
                .RuleFor(x => x.CaloriesG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.CarbohydratesTotalG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.FatTotalG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.FatSaturatedG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.FiberG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.ProteinG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.SugarG, f => f.Random.Int(0, 100))
                .RuleFor(x => x.SodiumMg, f => f.Random.Int(0, 100))
                .RuleFor(x => x.PotassiumMg, f => f.Random.Int(0, 100))
                .RuleFor(x => x.CholesterolMg, f => f.Random.Int(0, 100))
                .RuleFor(x => x.Name, f => f.PickRandom(NameList))
                .Generate();

            return response;
       }

       public static readonly List<string> NameList = new List<string>
       {
        "Patato",
        "Tomato",
        "Cheese",
        "Carrot",
        "Apple",
        "Bnana",
       };
    }
}