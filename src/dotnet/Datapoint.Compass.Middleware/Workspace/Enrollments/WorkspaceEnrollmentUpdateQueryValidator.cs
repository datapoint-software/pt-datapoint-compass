using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateQueryValidator : AbstractValidator<WorkspaceEnrollmentUpdateQuery>
    {
        public WorkspaceEnrollmentUpdateQueryValidator()
        {
            RuleFor(q => q.EnrollmentId);
        }
    }
}
