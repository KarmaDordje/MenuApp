namespace Recipe.Contracts.Ingredients
{
    public record CreateProductResponse(
        string IngredientId,
        string Name,
        string PolishName,
        decimal Calories,
        decimal Cholesterol,
        decimal FatSaturated,
        decimal FatTotal,
        int MeasuresType,
        decimal Potassium,
        decimal Protein,
        decimal Sodium,
        Measurement Measurement);

    public record Measurement(string Name, string ShortName);
}