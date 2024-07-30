using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilitySearch
    {
        public WorkspaceFacilitySearch(IEnumerable<WorkspaceFacilitySearchResult> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }

        public IEnumerable<WorkspaceFacilitySearchResult> Results { get; }

        public int TotalResultCount { get; }
    }
}