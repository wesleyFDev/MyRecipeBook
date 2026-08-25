using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.communication.Responses;
using MyRecipeBook.exception;
using MyRecipeBook.exception.ExceptionsBase;

namespace MyRecipeBook.api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException errorOnValidationException)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                context.Result = new BadRequestObjectResult(new ResponseErrorJson(errorOnValidationException.GetErrorMessages()));
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new
                {
                    message = context.Exception.Message,
                    stackTrace = context.Exception.StackTrace,
                    innerException = context.Exception.InnerException?.Message
                });
                // context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                // context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.UNKNOWN_ERROR));
            }
        }
    }
}
