﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Recipe.Domain.Common.Models;
using Recipe.Domain.ValueObjects;

namespace Recipe.Domain.Entities
{
    public sealed class Ingredient : Entity<IngredientId>
    {
        public string Name { get; set; }
        public string PolishName { get; set; }
        public decimal Calories { get; private set; }
        public decimal Cholesterol { get; private set; }
        public decimal FatSaturated { get; private set; }
        public decimal FatTotal { get; private set; }
        public int MeasuresType { get; private set; }
        public decimal Potassium { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Sodium { get; private set; }
        public Measurement Measurement { get; private set; }

        private Ingredient(
            IngredientId id,
            string name,
            string polishName,
            decimal calories,
            decimal cholesterol,
            decimal fatSaturated,
            decimal fatTotal,
            int measuresType,
            decimal potassium,
            decimal protein,
            decimal sodium,
            Measurement measurement)
            : base(id)
        {
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

        public static Ingredient Create(
            IngredientId id,
            string name,
            string polishName,
            decimal calories,
            decimal cholesterol,
            decimal fatSaturated,
            decimal fatTotal,
            int measuresType,
            decimal potassium,
            decimal protein,
            decimal sodium,
            Measurement measurement)
        {
            return new Ingredient(
                IngredientId.CreateUnique(),
                name,
                polishName,
                calories,
                cholesterol,
                fatSaturated,
                fatTotal,
                measuresType,
                potassium,
                protein,
                sodium,
                measurement);
        }

        public void AddIngredient(string productName, decimal proportion)
        {

        }

        #pragma warning disable CS8618
        // private Ingredient()
        // {
        // }
        #pragma warning restore CS8618
    }
}
