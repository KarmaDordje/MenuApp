namespace Menu.Application.Menu.Commands;

using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using global::Menu.Contracts.Recipies.Consumers;
using global::Menu.Infrastructure.Messaging;
using MediatR;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Unit>>
{
    private readonly RecipeClient _recipeClient;

    public CreateMenuCommandHandler(RecipeClient recipeClient)
    {
        _recipeClient = recipeClient;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var req = new RecipeConsumerRequest { UserId = Guid.Parse(request.UserId) };
        var response = await _recipeClient.GetRecipesForUserAsync(req);
        throw new NotImplementedException();
    }

}