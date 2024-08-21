namespace User.API.Common.Mapping;

using AutoMapper;

using User.Application.User.Commands.CreateUser;
using User.Contracts.User;

public class UserMappingConfig : Profile
    {
        public UserMappingConfig()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
        }
    }