using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Exceptions;

public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        
        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = exception switch
            {
                ArgumentException argEx => CreateBadRequestProblemDetails(argEx),
                UnauthorizedAccessException unAuthEx => CreateUnauthorizedProblemDetails(unAuthEx),
                EntityNotFoundException entityNotFoundEx => CreateNotFoundProblemDetails(entityNotFoundEx),
                DuplicatedEntityException duplicatedEntityEx => CreateDuplicatedProblemDetails(duplicatedEntityEx),
                _ => CreateInternalServerErrorProblemDetails(exception)
            }
        };

        httpContext.Response.StatusCode = problemDetailsContext.ProblemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
        return await problemDetailsService.TryWriteAsync(problemDetailsContext);
    }

    private ProblemDetails CreateNotFoundProblemDetails(EntityNotFoundException entityNotFoundEx)
    {
        return new ProblemDetails
        {
            Status = (int)HttpStatusCode.NotFound,
            Title = "Entity not found",
            Detail = entityNotFoundEx.Message,
            Type = entityNotFoundEx.GetType().Name
        };
    }
    
    private ProblemDetails CreateDuplicatedProblemDetails(DuplicatedEntityException duplicatedEntityEx)
    {
        return new ProblemDetails
        {
            Status = (int)HttpStatusCode.Conflict,
            Title = "Entity already exists",
            Detail = duplicatedEntityEx.Message,
            Type = duplicatedEntityEx.GetType().Name
        };
    }

    private ProblemDetails CreateBadRequestProblemDetails(ArgumentException exception)
    {
        return new ProblemDetails
        {
            Status = (int)HttpStatusCode.BadRequest,
            Title = "Invalid argument",
            Detail = exception.Message,
            Type = exception.GetType().Name
        };
    }

    private ProblemDetails CreateUnauthorizedProblemDetails(UnauthorizedAccessException exception)
    {
        return new ProblemDetails
        {
            Status = (int)HttpStatusCode.Unauthorized,
            Title = "Unauthorized access",
            Detail = "You do not have permission to access this resource.",
            Type = exception.GetType().Name
        };
    }

    private ProblemDetails CreateInternalServerErrorProblemDetails(Exception exception)
    {
        return new ProblemDetails
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Title = "An error occurred",
            Detail = exception.Message,
            Type = exception.GetType().Name
        };
    }
}