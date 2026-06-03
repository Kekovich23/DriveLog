using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class RaceRequestModelValidator : AbstractValidator<RaceRequestModel> {
    public RaceRequestModelValidator() {
        RuleFor(x => x.TrackId)
            .NotEmpty().WithMessage("Track ID must not be empty.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Race date is required.");
    }
}
