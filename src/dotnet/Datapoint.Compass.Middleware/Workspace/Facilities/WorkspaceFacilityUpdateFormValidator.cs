using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateFormValidator : AbstractValidator<WorkspaceFacilityUpdateForm>
    {
        public WorkspaceFacilityUpdateFormValidator(bool update)
        {
            RuleFor(c => c.Code)
                .MaximumLength(16)
                .NotEmpty()
                .When(x => update is false);

            RuleFor(c => c.Code)
                .Null()
                .When(x => update is true);

            RuleFor(c => c.Name)
                .MaximumLength(128)
                .NotEmpty();

            RuleFor(c => c.Description)
                .MaximumLength(4096);
        }
    }
}