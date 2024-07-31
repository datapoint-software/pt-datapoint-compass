using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceSearchQueryValidator : AbstractValidator<WorkspaceServiceSearchQuery>
    {
        public WorkspaceServiceSearchQueryValidator()
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
