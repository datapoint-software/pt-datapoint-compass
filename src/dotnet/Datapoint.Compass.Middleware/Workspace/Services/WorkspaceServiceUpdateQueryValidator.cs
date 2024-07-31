using FluentValidation;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceUpdateQueryValidator : AbstractValidator<WorkspaceServiceUpdateQuery>
    {
        public WorkspaceServiceUpdateQueryValidator()
        {
            RuleFor(q => q.ServiceId);
        }
    }
}
