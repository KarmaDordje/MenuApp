

namespace Account.API.Common.Mapping;
using AutoMapper;
using Account.Contracts.Account;
using Account.Application.AccountRegistrations.RegisterNewAccount;


using SharedCore.Contracts.Consumers.Recipe;
using SharedCore.Enums;

public class AccountMappingConfig : Profile
    {
        public AccountMappingConfig()
        {
            CreateMap<CreateAccountRequest, RegisterNewAccountCommand>();
        }

    }
