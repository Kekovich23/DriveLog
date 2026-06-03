using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class RecordLapTimeRequestModelValidator : AbstractValidator<RecordLapTimeRequestModel> {
    public RecordLapTimeRequestModelValidator() {
        RuleFor(x => x.DriverId)
            .NotEmpty().WithMessage("Driver ID must not be empty.");

        RuleFor(x => x.Duration)
            .GreaterThan(TimeSpan.Zero).WithMessage("Duration must be greater than 0.");
    }
}
