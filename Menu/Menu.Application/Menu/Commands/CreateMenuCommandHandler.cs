namespace Menu.Application.Menu.Commands;

using System.Threading;
using System.Threading.Tasks;
using ErrorOr;

using global::Menu.Domain.MenuAggregate.ValueObjects;

using global::Menu.Infrastructure.Messaging;
using MediatR;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


using SharedCore.Contracts.Consumers.Recipe;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Unit>>
{
    private readonly RecipeClient _recipeClient;

    public CreateMenuCommandHandler(RecipeClient recipeClient)
    {
        _recipeClient = recipeClient;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {   
        var menuId = MenuId.CreateUnique().Value;
    
        var req = new RecipeConsumerRequest { UserId = request.UserId };
        var response = await _recipeClient.GetRecipesForUserAsync(req);
        throw new NotImplementedException();
    }

}