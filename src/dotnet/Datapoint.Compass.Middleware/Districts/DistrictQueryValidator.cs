using FluentValidation;

namespace Datapoint.Compass.Middleware.Districts
{
    public sealed class DistrictQueryValidator : AbstractValidator<DistrictQuery>
    {
        public DistrictQueryValidator()
        {
            RuleFor(q => q.DistrictCode)
                .MaximumLength(16);

            RuleFor(q => q.CountryCode)
                .Length(2);

            RuleFor(q => q.Name)
                .MaximumLength(64);

            RuleFor(q => q.Skip)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.Take)
                .GreaterThanOrEqualTo(0);
        }
    }
}
