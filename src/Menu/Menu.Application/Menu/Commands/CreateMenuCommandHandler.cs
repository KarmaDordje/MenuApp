namespace Menu.Application.Menu.Commands;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;

using global::Menu.Application.Common.Intefaces.CreareMenu;

using global::Menu.Contracts.Menu;
using global::Menu.Domain.MenuAggregate;
using global::Menu.Infrastructure.Messaging;
using MediatR;

using SharedCore.Contracts.Consumers.Recipe;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Unit>>
{
    private readonly RecipeClient _recipeClient;
    private readonly IMapper _mapper;
    private readonly ICreateMenuService _createMenuService;
    private readonly IMenuRepositury _menuRepositury;

    public CreateMenuCommandHandler(
        RecipeClient recipeClient,
        ICreateMenuService createMenuService,
        IMapper mapper,
        IMenuRepositury menuRepositury)
    {
        _recipeClient = recipeClient;
        _createMenuService = createMenuService;
        _mapper = mapper;
        _menuRepositury = menuRepositury;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {

        var req = new RecipeConsumerRequest { UserId = request.UserId };
        var recipes = await _recipeClient.GetRecipesForUserAsync(req);
        var dto = _mapper.Map<List<RecipeDTO>>(recipes.Recipes);
        var menu = _createMenuService.GenerateMenu(
            request.UserId,
            request.StartDate,
            request.Days,
            request.MealTypes,
            dto);
        
        await _menuRepositury.AddAsync(menu.Value);

        return Unit.Value;

    }

}