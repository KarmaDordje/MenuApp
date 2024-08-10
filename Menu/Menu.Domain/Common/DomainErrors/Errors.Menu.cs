namespace Menu.Domain.Common.DomainErrors;
using ErrorOr;
public static partial class Errors
{

    public static partial class Menu
    {
        public static Error NotEnoughtRecipies => Error.Validation(
            code: "Menu.Recipes",
            description: "Not enough recipes to create a menu.");
    }
}