namespace User.Application.User.Commands.CreateUser;

using ErrorOr;
using MediatR;
    public class CreateUserCommand : IRequest<ErrorOr<Unit>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationLink { get; set; }
    }