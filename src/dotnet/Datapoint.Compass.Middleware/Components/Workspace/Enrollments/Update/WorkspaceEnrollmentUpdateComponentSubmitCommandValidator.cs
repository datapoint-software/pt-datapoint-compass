using FluentValidation;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentSubmitCommandValidator : AbstractValidator<WorkspaceEnrollmentUpdateComponentSubmitCommand>
    {
        public WorkspaceEnrollmentUpdateComponentSubmitCommandValidator()
        {
            RuleFor(c => c.EnrollmentId);

            RuleFor(c => c.EnrollmentRowVersionId)
                .NotEmpty()
                .When(c => c.EnrollmentId.HasValue);

            RuleFor(c => c.Form)
                .NotEmpty()
                .SetValidator(c => new WorkspaceEnrollmentUpdateComponentFormValidator(c.EnrollmentId is null));
        }
    }
}
