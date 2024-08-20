namespace Menu.Domain.MenuAggregate.Rules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ErrorOr;
    using global::Menu.Domain.Common.DomainErrors;
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.MenuAggregate.Entities;
    
    public class CantAddMealWithTheSameCategory : IBusinessRule
    {
        private readonly List<Meal> _meals;
        private readonly Meal _newMeal;

        internal CantAddMealWithTheSameCategory(List<Meal> meals, Meal newMeal)
        {
            _meals = meals;
            _newMeal = newMeal;
        }

        public bool IsBroken() => _meals.Any(meal => meal.MealType == _newMeal.MealType);
       
        public string Message => "You can't add meals with the same category.";
    }
}