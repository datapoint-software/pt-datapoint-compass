using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchResultModel
    {
        public WorkspaceEnrollmentSearchComponentSearchResultModel(int totalMatchCount, IEnumerable<WorkspaceEnrollmentSearchComponentSearchResultMatchModel> matches)
        {
            TotalMatchCount = totalMatchCount;
            Matches = matches;
        }

        public int TotalMatchCount { get; }

        public IEnumerable<WorkspaceEnrollmentSearchComponentSearchResultMatchModel> Matches { get; }
    }
}
