using Account.Application.AccountRegistrations.RegisterNewAccount;
using Account.Contracts.Account;

namespace Account.API.Controllers;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class AccountController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateAccountRequest request)
    {   
        var command = _mapper.Map<RegisterNewAccountCommand>(request);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            _ => Ok(),
            error => BadRequest(error));
    }
}