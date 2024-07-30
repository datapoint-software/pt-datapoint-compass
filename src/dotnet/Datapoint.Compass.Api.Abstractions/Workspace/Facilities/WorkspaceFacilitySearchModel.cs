using System.Collections.Generic;

namespace Datapoint.Compass.Api.Workspace.Facilities
{
    public sealed class WorkspaceFacilitySearchModel
    {
        public WorkspaceFacilitySearchModel(IEnumerable<WorkspaceFacilitySearchResultModel> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }

        public IEnumerable<WorkspaceFacilitySearchResultModel> Results { get; }

        public int TotalResultCount { get; }
    }
}