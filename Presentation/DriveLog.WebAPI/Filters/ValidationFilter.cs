using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DriveLog.WebAPI.Filters;

public class ValidationFilter(IServiceProvider serviceProvider) : IAsyncActionFilter {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        foreach (var argument in context.ActionArguments.Values) {
            if (argument == null) {
                continue;
            }

            var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
            var validator = serviceProvider.GetService(validatorType);

            if (validator == null) {
                continue;
            }

            var validationMethod = validatorType.GetMethod("ValidateAsync", [argument.GetType(), typeof(CancellationToken)]);
            if (validationMethod == null) {
                continue;
            }

            var result = await (Task<ValidationResult>)validationMethod.Invoke(validator, [argument, context.HttpContext.RequestAborted])!;

            if (!result.IsValid) {
                context.Result = new BadRequestObjectResult(new ProblemDetails {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "One or more validation errors occurred.",
                    Detail = "Please check the errors field for details.",
                    Instance = context.HttpContext.Request.Path,
                    Extensions = new Dictionary<string, object?> {
                        { 
                            "errors", 
                            result.Errors.GroupBy(e => e.PropertyName)
                                         .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray()) } 
                    }
                });

                return;
            }
        }

        await next();
    }
}
