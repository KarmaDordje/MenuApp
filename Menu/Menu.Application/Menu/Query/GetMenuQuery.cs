namespace Menu.Application.Menu.Query
{
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using global::Menu.Contracts.Menu;
    using MediatR;

    public record GetMenuQuery(Guid MenuId) : IRequest<ErrorOr<GetMenuResponse>>;
    
}