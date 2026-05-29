using DriveLog.ValueObjects.Exceptions;
using DriveLog.ValueObjects.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;

namespace DriveLog.WebAPI;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) {
    public async Task InvokeAsync(HttpContext context) {
        try {
            await next(context);
        } catch (DomainException ex) {
            logger.LogWarning(ex, "A domain exception occurred while processing the request.");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(new ProblemDetails {
                Status = StatusCodes.Status400BadRequest,
                Title = "A domain error occurred.",
                Detail = ex.Message,
                Instance = context.Request.Path
            });
        } catch (EntityNotFoundException ex) {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(new ProblemDetails {
                Status = StatusCodes.Status404NotFound,
                Title = "Entity not found.",
                Detail = ex.Message,
                Instance = context.Request.Path
            });
        } catch (Exception ex) {
            logger.LogError(ex, "An unhandled exception occurred while processing the request.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(new ProblemDetails {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An internal server error occurred.",
                Detail = ex.Message,
                Instance = context.Request.Path
            });
        }
    }
}
