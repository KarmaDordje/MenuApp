# Domain Aggregats

## Menu

```csharp
class Menu
{
    // TODO: Add methods
}
```

```json
{
    "id" : "00000000-0000-0000-0000-000000000000",
    "name" : "My Menu",
    "description" : "A menu with random recipes",
    "usersId" : "00000000-0000-0000-0000-000000000000",
    "menuDays": [
        {
            "menuId" : "00000000-0000-0000-0000-000000000000",
            "dayOfWeek" : "Monday",
            "date" : "2024-01-01T00:00:00.0000000Z",
            "meals" : [
                {
                    "menuDayId" : "00000000-0000-0000-0000-000000000000",
                    "recipeName" : "Bwonie",
                    "recipeDescription" : "Sweet cookies",
                    "recipeImageUrl" : "https://my-img-url.com",
                    "userId" : "00000000-0000-0000-0000-000000000000",
                    "mealType" : "Dinner"
                }
            ]
        },
        {
            "menuId" : "00000000-0000-0000-0000-000000000000",
            "dayOfWeek" : "Thusday",
            "date" : "2024-01-01T00:00:00.0000000Z",
            "meals" : [
                {
                    "menuDayId" : "00000000-0000-0000-0000-000000000000",
                    "recipeName" : "Bwonie",
                    "recipeDescription" : "Sweet cookies",
                    "recipeImageUrl" : "https://my-img-url.com",
                    "userId" : "00000000-0000-0000-0000-000000000000",
                    "mealType" : "Dinner"
                }
            ]
        }
    ]
}