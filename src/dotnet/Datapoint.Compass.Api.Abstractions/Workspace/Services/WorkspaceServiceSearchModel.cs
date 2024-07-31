using System.Collections.Generic;

namespace Datapoint.Compass.Api.Workspace.Services
{
    public sealed class WorkspaceServiceSearchModel
    {
        public WorkspaceServiceSearchModel(IEnumerable<WorkspaceServiceSearchResultModel> results, int totalResultCount)
        {
            Results = results;
            TotalResultCount = totalResultCount;
        }

        public IEnumerable<WorkspaceServiceSearchResultModel> Results { get; }

        public int TotalResultCount { get; }
    }
}