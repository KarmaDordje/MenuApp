using Recipe.Domain.Common.Models;
using Recipe.Domain.IngredientAggregate.ValueObjects;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.IngredientAggregate
{
    public sealed class Ingredient : Entity<IngredientId>
    {
        public string Name { get; private set; }
        public string PolishName { get; private set; }
        public decimal Calories { get; private set; }
        public decimal Cholesterol { get; private set; }
        public decimal FatSaturated { get; private set; }
        public decimal FatTotal { get; private set; }
        public decimal Potassium { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Sodium { get; private set; }
        public decimal Sugar { get; private set; }
        public Measurement Measurement { get; private set; }

        private Ingredient(
            IngredientId id,
            string name,
            string polishName,
            decimal calories,
            decimal cholesterol,
            decimal fatSaturated,
            decimal fatTotal,
            decimal potassium,
            decimal protein,
            decimal sodium,
            decimal sugar,
            Measurement measurement)
            : base(id)
        {
            Name = name;
            PolishName = polishName;
            Calories = calories;
            Cholesterol = cholesterol;
            FatSaturated = fatSaturated;
            FatTotal = fatTotal;
            Potassium = potassium;
            Protein = protein;
            Sodium = sodium;
            Sugar = sugar;
            Measurement = measurement;
        }

        public static Ingredient Create(
            IngredientId id,
            string name,
            string polishName,
            decimal calories,
            decimal cholesterol,
            decimal fatSaturated,
            decimal fatTotal,
            decimal potassium,
            decimal protein,
            decimal sodium,
            decimal sugar,
            Measurement measurement)
        {

            return new Ingredient(
                IngredientId.CreateUnique(),
                name.ToLower(),
                polishName.ToLower(),
                calories,
                cholesterol,
                fatSaturated,
                fatTotal,
                potassium,
                protein,
                sodium,
                sugar,
                measurement);
        }

        #pragma warning disable CS8618
        private Ingredient()
        {
        }
        #pragma warning restore CS8618
    }
}
