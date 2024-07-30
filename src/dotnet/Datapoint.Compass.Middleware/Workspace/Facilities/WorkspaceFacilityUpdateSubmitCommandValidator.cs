using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateSubmitCommandValidator : AbstractValidator<WorkspaceFacilityUpdateSubmitCommand>
    {
        public WorkspaceFacilityUpdateSubmitCommandValidator()
        {
            RuleFor(c => c.FacilityId);

            RuleFor(c => c.FacilityRowVersionId)
                .NotEmpty()
                .When(c => c.FacilityId.HasValue);

            RuleFor(c => c.Form)
                .NotNull()
                .SetValidator(c => new WorkspaceFacilityUpdateFormValidator(c.FacilityId.HasValue));
        }
    }
}
