namespace User.API.Controllers;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using User.Application.User.Commands.CreateUser;
using User.Contracts.User;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IMediator mediator, 
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {   
            var command = _mapper.Map<CreateUserCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                unit => Ok(),
                errors => BadRequest(errors));
        }
    }