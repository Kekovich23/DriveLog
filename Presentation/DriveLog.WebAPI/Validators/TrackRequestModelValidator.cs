using DriveLog.ValueObjects;
using DriveLog.WebAPI.Models.Requests;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class TrackRequestModelValidator : AbstractValidator<TrackRequestModel> {
    public TrackRequestModelValidator() {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Track name is required.")
            .MaximumLength(TrackName.MaxLength).WithMessage($"Track name cannot exceed {TrackName.MaxLength} characters.");
    }
}
