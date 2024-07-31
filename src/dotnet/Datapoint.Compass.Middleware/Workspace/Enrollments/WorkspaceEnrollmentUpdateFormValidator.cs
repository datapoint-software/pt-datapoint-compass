using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateFormValidator : AbstractValidator<WorkspaceEnrollmentUpdateForm>
    {
        public WorkspaceEnrollmentUpdateFormValidator(bool update)
        {
            RuleFor(c => c.FacilityId)
                .NotEmpty();

            RuleFor(c => c.ServiceId)
                .NotEmpty();

            RuleFor(c => c.Start);
        }
    }
}
