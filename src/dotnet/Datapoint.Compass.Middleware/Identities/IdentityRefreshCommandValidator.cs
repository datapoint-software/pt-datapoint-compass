using FluentValidation;

namespace Datapoint.Compass.Middleware.Identities
{
    public sealed class IdentityRefreshCommandValidator : AbstractValidator<IdentityRefreshCommand>
    {
        public IdentityRefreshCommandValidator()
        {
            RuleFor(c => c.IdentityKind)
                .IsInEnum()
                .NotEmpty();

            RuleFor(c => c.IdentitySessionId)
                .NotEmpty();
        }
    }
}
