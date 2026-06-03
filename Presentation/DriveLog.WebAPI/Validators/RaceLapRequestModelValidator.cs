using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class RaceLapRequestModelValidator : AbstractValidator<RaceLapRequestModel> {
    public RaceLapRequestModelValidator() {
        RuleFor(x => x.RaceId)
            .NotEmpty().WithMessage("Race ID must not be empty.");

        RuleFor(x => x.DriverId)
            .NotEmpty().WithMessage("Driver ID must not be empty.");

        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("Car ID must not be empty.");

        RuleFor(x => x.LapNumber)
            .GreaterThan(0).WithMessage("Lap number must be greater than 0.");

        RuleFor(x => x.LapTime)
            .GreaterThan(TimeSpan.Zero).WithMessage("Lap time must be greater than 0.");
    }
}
