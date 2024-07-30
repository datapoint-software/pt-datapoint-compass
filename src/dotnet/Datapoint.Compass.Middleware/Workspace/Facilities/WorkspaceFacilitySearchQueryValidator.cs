using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilitySearchQueryValidator : AbstractValidator<WorkspaceFacilitySearchQuery>
    {
        public WorkspaceFacilitySearchQueryValidator()
        {
            RuleFor(c => c.Filter)
                .MaximumLength(128);

            RuleFor(q => q.Skip)
                .GreaterThanOrEqualTo(0);

            RuleFor(q => q.Take)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(25);
        }
    }
}
