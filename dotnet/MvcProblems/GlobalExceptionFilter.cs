using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
// ReSharper disable ConvertToPrimaryConstructor
// ReSharper disable UnusedType.Global

namespace MvcProblems;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public GlobalExceptionFilter(ProblemDetailsFactory problemDetailsFactory)
    {
        _problemDetailsFactory = problemDetailsFactory;
    }
    
    public void OnException(ExceptionContext context)
    {
        // Log error
        
        var problemDetails = _problemDetailsFactory
            .CreateProblemDetails(context.HttpContext, StatusCodes.Status500InternalServerError);

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }
}