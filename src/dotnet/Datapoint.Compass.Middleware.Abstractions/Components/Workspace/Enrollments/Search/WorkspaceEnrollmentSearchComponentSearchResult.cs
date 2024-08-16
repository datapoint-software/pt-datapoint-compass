using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchResult
    {
        public WorkspaceEnrollmentSearchComponentSearchResult(int totalMatchCount, IEnumerable<WorkspaceEnrollmentSearchComponentSearchResultMatch> matches)
        {
            TotalMatchCount = totalMatchCount;
            Matches = matches;
        }

        public int TotalMatchCount { get; }

        public IEnumerable<WorkspaceEnrollmentSearchComponentSearchResultMatch> Matches { get; }
    }
}