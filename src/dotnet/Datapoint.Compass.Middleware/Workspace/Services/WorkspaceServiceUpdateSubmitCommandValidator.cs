using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateSubmitCommandValidator : AbstractValidator<WorkspaceServiceUpdateSubmitCommand>
    {
        public WorkspaceServiceUpdateSubmitCommandValidator()
        {
            RuleFor(c => c.ServiceId);

            RuleFor(c => c.ServiceRowVersionId)
                .NotEmpty()
                .When(c => c.ServiceId.HasValue);

            RuleFor(c => c.Form)
                .NotNull()
                .SetValidator(c => new WorkspaceServiceUpdateFormValidator(c.ServiceId.HasValue));
        }
    }
}
