namespace User.Application.User.Commands.CreateUser;

using ErrorOr;
using global::User.Domain.UserAggregate;
using MediatR;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {   
        private readonly IUserRepository _userRepository;
        private readonly IUsersCounter _usersCounter;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IUsersCounter usersCounter)
        {
            _userRepository = userRepository;
            _usersCounter = usersCounter;
        }
        
        public Task<ErrorOr<Unit>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {   
            var password = PasswordManager.HashPassword(command.Password);

            var user = User.Create(
                command.FirstName,
                command.LastName,
                command.Login,
                command.Email,
                password,
                _usersCounter,
                command.ConfirmationLink);
            
            throw new NotImplementedException();
        }
    }