using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UKParliament.CodeTest.Services.Exceptions;

namespace UKParliament.CodeTest.Web;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path
        };

        if (exception is PersonNotFoundException e)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            problemDetails.Title = e.Message;
        }
        else
        {
            problemDetails.Title = exception.Message;
        }

        logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);
        problemDetails.Status = httpContext.Response.StatusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
