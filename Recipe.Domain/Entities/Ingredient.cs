using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.Entities
{
    public class Ingredient:BaseEntity
    {
        public string Name { get;  set; }
        public string PolishName { get;  set; }
        public decimal Calories { get; private set; }
        public decimal Cholesterol { get; private set; }
        public decimal FatSaturated { get; private set; }
        public decimal FatTotal { get; private set; }
        public int MeasuresType { get; private set; }
        public decimal Potassium { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Sodium { get; private set; }
        public Measurement Measurement { get; private set; }

        public Ingredient(string name, string polishName, decimal calories, decimal cholesterol,
            decimal fatSaturated, decimal fatTotal, int measuresType, decimal potassium, decimal protein, decimal sodium, Measurement measurement)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Ingredient name cannot be null or empty.", nameof(name));
            }

            Name = name;
            PolishName = polishName;
            Calories = calories;
            Cholesterol = cholesterol;
            FatSaturated = fatSaturated;
            FatTotal = fatTotal;
            MeasuresType = measuresType;
            Potassium = potassium;
            Protein = protein;
            Sodium = sodium;
            Measurement = measurement;
        }

        public void AddIngredient(string productName, decimal proportion)
        {

        }

        private Ingredient() { }
    }
}
