using FluentValidation;
using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentFormValidator : AbstractValidator<WorkspaceEnrollmentUpdateComponentForm>
    {
        public WorkspaceEnrollmentUpdateComponentFormValidator(bool creating)
        {
            RuleFor(f => f.ServiceId)
                .NotEmpty()
                .When(f => creating);

            RuleFor(f => f.FacilityId);

            RuleFor(f => f.Start);

            RuleFor(f => f.Comments)
                .MaximumLength(4096);
        }
    }
}
