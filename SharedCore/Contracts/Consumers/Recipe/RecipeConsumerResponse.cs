namespace SharedCore.Contracts.Consumers.Recipe;
using System;

public class RecipeConsumerRequest
{
    public string RecipeName { get; set; }
    public string RecipeId { get; set; }
    public decimal AvarageRating { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }

}