namespace Menu.Application.Menu.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using MediatR;

    public class CreateMenuCommand : IRequest<ErrorOr<Unit>>
    {
        public string UserId { get; set; }
        public int Days { get; set; }
    }

}