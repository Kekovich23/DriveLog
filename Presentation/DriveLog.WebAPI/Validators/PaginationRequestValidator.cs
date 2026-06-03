using DriveLog.WebAPI.Models.Pagination;
using FluentValidation;

namespace DriveLog.WebAPI.Validators;

public class PaginationRequestValidator : AbstractValidator<PaginationRequest> {
    public PaginationRequestValidator() {
        RuleFor(x => x.Skip)
            .GreaterThanOrEqualTo(0).WithMessage("Skip must be greater than or equal to 0.");

        RuleFor(x => x.Take)
            .InclusiveBetween(1, 100).WithMessage("Take must be between 1 and 100.");
    }
}
