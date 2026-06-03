using DriveLog.ValueObjects;
using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class DriverRequestModelValidator : AbstractValidator<DriverRequestModel> {
    public DriverRequestModelValidator() {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(DriverName.MaxLength).WithMessage($"First name cannot exceed {DriverName.MaxLength} characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(DriverName.MaxLength).WithMessage($"Last name cannot exceed {DriverName.MaxLength} characters.");

        RuleFor(x => x.Number)
            .GreaterThan(0).WithMessage("Driver number must be greater than 0.");
    }
}
