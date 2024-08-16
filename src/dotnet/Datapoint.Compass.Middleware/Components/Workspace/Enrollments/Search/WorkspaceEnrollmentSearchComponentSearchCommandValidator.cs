using FluentValidation;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchCommandValidator : AbstractValidator<WorkspaceEnrollmentSearchComponentSearchCommand>
    {
        public WorkspaceEnrollmentSearchComponentSearchCommandValidator()
        {
            RuleFor(c => c.Filter)
                .MaximumLength(128);

            RuleFor(c => c.ServiceId);

            RuleFor(c => c.FacilityId);

            RuleFor(c => c.Status)
                .IsInEnum();

            RuleFor(c => c.Skip)
                .GreaterThanOrEqualTo(0);

            RuleFor(c => c.Take)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(25);
        }
    }
}
