using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentModel
    {
        public WorkspaceEnrollmentSearchComponentModel(IEnumerable<WorkspaceEnrollmentSearchComponentServiceModel> services, IEnumerable<WorkspaceEnrollmentSearchComponentFacilityModel> facilities)
        {
            Services = services;
            Facilities = facilities;
        }

        public IEnumerable<WorkspaceEnrollmentSearchComponentServiceModel> Services { get; }

        public IEnumerable<WorkspaceEnrollmentSearchComponentFacilityModel> Facilities { get; }
    }
}
