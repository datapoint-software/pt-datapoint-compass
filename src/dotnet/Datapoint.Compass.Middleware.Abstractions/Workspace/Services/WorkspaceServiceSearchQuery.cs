using Datapoint.Mediator;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceSearchQuery : Query<WorkspaceServiceSearch>
    {
        public WorkspaceServiceSearchQuery(string? filter, int? skip, int? take)
        {
            Filter = filter;
            Skip = skip;
            Take = take;
        }

        public string? Filter { get; }

        public int? Skip { get; }

        public int? Take { get; }
    }
}
