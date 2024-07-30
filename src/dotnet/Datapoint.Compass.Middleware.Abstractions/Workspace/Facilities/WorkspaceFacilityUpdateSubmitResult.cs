using System;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateSubmitResult
    {
        public WorkspaceFacilityUpdateSubmitResult(Guid facilityId, Guid facilityRowVersionId)
        {
            FacilityId = facilityId;
            FacilityRowVersionId = facilityRowVersionId;
        }

        public Guid FacilityId { get; }

        public Guid FacilityRowVersionId { get; }
    }
}
