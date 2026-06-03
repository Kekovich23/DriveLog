using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class CarRequestModelValidator : AbstractValidator<CarRequestModel> {
    public CarRequestModelValidator() {
        RuleFor(x => x.Number)
            .GreaterThan(0).WithMessage("Car number must be greater than 0.");
    }
}
