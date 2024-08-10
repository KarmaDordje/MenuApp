namespace Menu.API.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;


    using ErrorOr;
    using MediatR;
    using Menu.Application.Menu.Commands;
    using Menu.Contracts.Menu;


    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MenuController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMenuRequest request)
        {   
            var command = _mapper.Map<CreateMenuCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                _ => Ok(),
                error => BadRequest(error));
        }
    }
}