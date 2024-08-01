using FluentValidation;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQueryValidator : AbstractValidator<DistrictQuery>
    {
        public DistrictQueryValidator()
        {
            RuleFor(q => q.CountryCode)
                .MaximumLength(2)
                .NotEmpty();
        }
    }
}
