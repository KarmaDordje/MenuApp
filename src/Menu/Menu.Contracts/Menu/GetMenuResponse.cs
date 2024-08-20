namespace Menu.Contracts.Menu;

public class GetMenuResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public List<MenuDayResponse> MenuDays { get; set; }
}

public record MenuResponse(
    Guid Id,
    string Name,
    string Description,
    Guid UserId);

public class MenuDayResponse
{
    public Guid MenuDayId { get; set; }
    public string DayOfWeek { get; set; }
    public DateTime Date { get; set; }
    public List<MealsResponse> Meals { get; set; }
}

public class MealsResponse
{
    public Guid MealId { get; set; }
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public string RecipeImageUrl { get; set; }
}