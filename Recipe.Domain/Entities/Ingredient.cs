using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Entities
{
    public class Ingredient:BaseEntity
    {
        public string Name { get;  set; }
        public decimal Proportion { get; private set; }
        public decimal Calories { get; private set; }
        public decimal Cholesterol { get; private set; }
        public decimal FatSaturated { get; private set; }
        public decimal FatTotal { get; private set; }
        public int MeasuresType { get; private set; }
        public decimal Potassium { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Sodium { get; private set; }

        public Ingredient(string name, decimal proportion, decimal calories, decimal cholesterol,
            decimal fatSaturated, decimal fatTotal, int measuresType, decimal potassium, decimal protein, decimal sodium)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ingredient name cannot be null or empty.", nameof(name));
            }

            Name = name;
            Proportion = proportion;
            Calories = calories;
            Cholesterol = cholesterol;
            FatSaturated = fatSaturated;
            FatTotal = fatTotal;
            MeasuresType = measuresType;
            Potassium = potassium;
            Protein = protein;
            Sodium = sodium;
        }

        public void AddIngredient(string productName, decimal proportion)
        {

        }

        private Ingredient() { }
    }
}
