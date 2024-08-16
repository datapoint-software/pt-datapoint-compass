using System.Collections.Generic;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponent
    {
        public WorkspaceEnrollmentSearchComponent(IEnumerable<WorkspaceEnrollmentSearchComponentService> services, IEnumerable<WorkspaceEnrollmentSearchComponentFacility> facilities)
        {
            Services = services;
            Facilities = facilities;
        }

        public IEnumerable<WorkspaceEnrollmentSearchComponentService> Services { get; }

        public IEnumerable<WorkspaceEnrollmentSearchComponentFacility> Facilities { get; }
    }
}
