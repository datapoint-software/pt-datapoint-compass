using System;

namespace Datapoint.Compass.Middleware.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdate
    {
        public WorkspaceFacilityUpdate(Guid? facilityId, Guid? facilityRowVersionId, WorkspaceFacilityUpdateForm? form)
        {
            FacilityId = facilityId;
            FacilityRowVersionId = facilityRowVersionId;
            Form = form;
        }

        public Guid? FacilityId { get; }

        public Guid? FacilityRowVersionId { get; }

        public WorkspaceFacilityUpdateForm? Form { get; }
    }
}
