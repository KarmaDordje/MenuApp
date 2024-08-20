namespace Menu.Application.Menu.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using ErrorOr;
    using global::Menu.Domain.Common.Shared;
    using MediatR;

    public class CreateMenuCommand : IRequest<ErrorOr<Unit>>
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public List<MealCategory> MealTypes { get; set; }
        public int Days { get; set; }
    }

}