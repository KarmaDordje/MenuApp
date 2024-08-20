namespace Recipe.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception.Message);
        }
    }
}
