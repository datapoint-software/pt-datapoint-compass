using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateQueryValidator : AbstractValidator<WorkspaceFacilityUpdateQuery>
    {
        public WorkspaceFacilityUpdateQueryValidator()
        {
            RuleFor(q => q.FacilityId);
        }
    }
}
