using FluentValidation;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateSubmitCommandValidator : AbstractValidator<WorkspaceEnrollmentUpdateSubmitCommand>
    {
        public WorkspaceEnrollmentUpdateSubmitCommandValidator()
        {
            RuleFor(c => c.EnrollmentRowVersionId)
                .NotEmpty()
                .When(c => c.EnrollmentId.HasValue);

            RuleFor(c => c.Form)
                .NotNull()
                .SetValidator(c => new WorkspaceEnrollmentUpdateFormValidator(c.EnrollmentId.HasValue));
        }
    }
}
