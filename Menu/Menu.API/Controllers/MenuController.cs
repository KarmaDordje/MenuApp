namespace Menu.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using ErrorOr;
    using MediatR;
    using Menu.Application.Menu.Commands;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                _ => Ok(),
                error => BadRequest(error));
        }
    }
}