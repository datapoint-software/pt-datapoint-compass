using FluentValidation;

namespace Datapoint.Compass.Middleware.Features.Identity
{
    public sealed class IdentityFeatureSignInCommandValidator : AbstractValidator<IdentityFeatureSignInCommand>
    {
        public IdentityFeatureSignInCommandValidator()
        {
            RuleFor(c => c.RemoteAddress)
                .NotEmpty();

            RuleFor(c => c.UserAgent)
                .MaximumLength(4096)
                .NotEmpty();

            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .MaximumLength(128)
                .NotEmpty();

            RuleFor(c => c.Password)
                .MaximumLength(1024)
                .NotEmpty();

            RuleFor(c => c.RememberMe);
        }
    }
}
