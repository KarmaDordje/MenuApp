namespace Menu.Application.Menu;
using Dapper;
using ErrorOr;
using MediatR;
using global::Menu.Application.Menu.Query;
using global::Menu.Contracts.Menu;
using global::Menu.Domain.Common.Data;
using System.Text.RegularExpressions;


public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, ErrorOr<GetMenuResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetMenuQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ErrorOr<GetMenuResponse>> Handle(GetMenuQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        var sql = 
            $"""
             SELECT 
                MN."Id" as {nameof(MenuResponse.Id)},
                MN."Name" as {nameof(MenuResponse.Name)},
                MN."Description" as {nameof(MenuResponse.Description)},
                MN."UserId" as {nameof(MenuResponse.UserId)}
             FROM "Menus" as MN
             WHERE MN."Id" = @MenuId;
            """;
        var menu = await connection.QueryFirstOrDefaultAsync<MenuResponse>(sql, new { query.MenuId });
        var menuDays = await connection.QueryAsync<MenuDayResponse, MealsResponse, MenuDayResponse>(
            $"""
            SELECT
                MD."MenuDayId",  -- Add the unique ID of MenuDay for the splitOn
                MD."DayOfWeek",
                MD."Date",
                M."RecipeName",
                M."RecipeDescription",
                M."RecipeImageUrl",
                M."MealId"
            FROM "MenuDays" MD
            INNER JOIN public."Meals" M on MD."MenuDayId" = M."MenuDayId"
            WHERE MD."MenuId" = @MenuId;
            """,
            (menuDay, meal) =>
            {
                menuDay.Meals = menuDay.Meals ?? new List<MealsResponse>();
                menuDay.Meals.Add(meal);
                return menuDay;
            },
            new { query.MenuId },
            splitOn: "MealId");
        
        var groupedMenuDays = menuDays
            .GroupBy(md => md.DayOfWeek)
            .Select(g =>
            {
                // We assume that within the same DayOfWeek, there's only one MenuDayId and Date.
                var firstDay = g.First();
                firstDay.Meals = g.SelectMany(md => md.Meals).ToList();
                return firstDay;
            })
            .ToList();
       
        var menuResponse = new GetMenuResponse
        {
            Id = menu.Id,
            Name = menu.Name,
            Description = menu.Description,
            UserId = menu.UserId,
            MenuDays = groupedMenuDays
        };
        return new ErrorOr<GetMenuResponse>();
    }
}