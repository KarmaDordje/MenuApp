namespace Recipe.Domain.RecipeAggregate.Rules;

using global::Recipe.Domain.Common.Models;
using global::Recipe.Domain.ValueObjects;

public class CantDeleteIngredientIfNotFoundRule : IBusinessRule
    {
        private readonly RecipeIngredient _ingredientName;

        public CantDeleteIngredientIfNotFoundRule(RecipeIngredient ingredientName)
        {
            _ingredientName = ingredientName;
        }

        public string Message => $"Ingredient with name {_ingredientName} not found.";

        public bool IsBroken() => _ingredientName is null;
    }