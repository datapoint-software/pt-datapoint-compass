using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Workspace.Services
{
    public sealed class WorkspaceServiceSearch
    {
        public WorkspaceServiceSearch(IEnumerable<WorkspaceServiceSearchResult> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }

        public IEnumerable<WorkspaceServiceSearchResult> Results { get; }

        public int TotalResultCount { get; }
    }
}