using FluentValidation;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentQueryValidator : AbstractValidator<WorkspaceEnrollmentUpdateComponentQuery>
    {
        public WorkspaceEnrollmentUpdateComponentQueryValidator()
        {
            RuleFor(q => q.EnrollmentId);
        }
    }
}
