using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class RegisterDriverRequestModelValidator : AbstractValidator<RegisterDriverRequestModel> {
    public RegisterDriverRequestModelValidator() {
        RuleFor(x => x.DriverId)
            .NotEmpty().WithMessage("Driver ID must not be empty.");

        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("Car ID must not be empty.");
    }
}
