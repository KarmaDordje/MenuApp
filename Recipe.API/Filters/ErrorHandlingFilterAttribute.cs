using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Recipe.API.Filters
{
    public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            context.Result = new ObjectResult(new { error = context.Exception.Message })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;


        }
    }
}
