using Datapoint.Mediator;
using System;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateQuery : Query<WorkspaceFacilityUpdate>
    {
        public WorkspaceFacilityUpdateQuery(Guid? facilityId)
        {
            FacilityId = facilityId;
        }

        public Guid? FacilityId { get; }
    }
}
