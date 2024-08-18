using FluentValidation;

namespace Datapoint.Compass.Middleware.Countries
{
    public sealed class CountryQueryValidator : AbstractValidator<CountryQuery>
    {
        public CountryQueryValidator()
        {
            RuleFor(q => q.Code)
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
