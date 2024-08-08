namespace Menu.Application.Menu.Commands;

using System.Threading;
using System.Threading.Tasks;
using ErrorOr;

using global::Menu.Domain.MenuAggregate.ValueObjects;
using global::Menu.Domain.Sercives;
using global::Menu.Infrastructure.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


using SharedCore.Contracts.Consumers.Recipe;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Unit>>
{
    private readonly RecipeClient _recipeClient;
    private readonly ICreateMenuService _createMenuService;

    public CreateMenuCommandHandler(
        RecipeClient recipeClient,
        ICreateMenuService createMenuService)
    {
        _recipeClient = recipeClient;
        _createMenuService = createMenuService;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {

        var req = new RecipeConsumerRequest { UserId = request.UserId };
        var recipes = await _recipeClient.GetRecipesForUserAsync(req);

        foreach (var recipe in recipes.Recipes)
        {
            //var meal = _createMenuService.CreateMealAsync(recipe.RecipeName, recipe.);
        }
        throw new NotImplementedException();
    }

}