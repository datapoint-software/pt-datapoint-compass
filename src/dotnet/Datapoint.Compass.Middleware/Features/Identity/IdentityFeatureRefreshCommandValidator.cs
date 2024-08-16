using Datapoint.Compass.Enumerations;
using FluentValidation;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeatureRefreshCommandValidator : AbstractValidator<IdentityFeatureRefreshCommand>
    {
        public IdentityFeatureRefreshCommandValidator()
        {
            RuleFor(q => q.IdentitySessionId)
                .NotEmpty()
                .When(q => q.IdentityKind is not IdentityKind.Anonymous);
        }
    }
}
