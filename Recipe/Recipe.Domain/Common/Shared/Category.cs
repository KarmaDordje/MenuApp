namespace Recipe.Domain.Common.Shared;
using System.ComponentModel.DataAnnotations;

public enum Category
    {
        [Display(Name = "Breakfast")]
        Breakfast,

        [Display(Name = "Lunch")]
        Lunch,

        [Display(Name = "Dinner")]
        Dinner,

        [Display(Name = "Dessert")]
        Dessert,

        [Display(Name = "Snack")]
        Snack,
    }