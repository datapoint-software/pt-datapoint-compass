using Datapoint.Mediator;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilitySearchQuery : Query<WorkspaceFacilitySearch>
    {
        public WorkspaceFacilitySearchQuery(string? filter, int? skip, int? take)
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
