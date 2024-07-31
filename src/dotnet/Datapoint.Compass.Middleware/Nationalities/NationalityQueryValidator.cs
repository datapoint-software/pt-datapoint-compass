using FluentValidation;

namespace Datapoint.Compass.Middleware.Nationalities
{
    public sealed class NationalityQueryValidator : AbstractValidator<NationalityQuery>
    {
        public NationalityQueryValidator()
        {
            RuleFor(q => q.Locale)
                .IsInEnum();
        }
    }
}
