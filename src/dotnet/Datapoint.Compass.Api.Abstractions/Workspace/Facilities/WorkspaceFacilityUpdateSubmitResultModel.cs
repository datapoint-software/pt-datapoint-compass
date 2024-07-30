using System;

namespace Datapoint.Compass.Api.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateSubmitResultModel
    {
        public WorkspaceFacilityUpdateSubmitResultModel(Guid facilityId, Guid facilityRowVersionId)
        {
            FacilityId = facilityId;
            FacilityRowVersionId = facilityRowVersionId;
        }

        public Guid FacilityId { get; }

        public Guid FacilityRowVersionId { get; }
    }
}
