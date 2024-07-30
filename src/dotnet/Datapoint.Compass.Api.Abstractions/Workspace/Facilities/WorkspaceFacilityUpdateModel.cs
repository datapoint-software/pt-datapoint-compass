using System;

namespace Datapoint.Compass.Api.Workspace.Facilities
{
    public sealed class WorkspaceFacilityUpdateModel
    {
        public WorkspaceFacilityUpdateModel(Guid? facilityId, Guid? facilityRowVersionId, WorkspaceFacilityUpdateFormModel? form)
        {
            FacilityId = facilityId;
            FacilityRowVersionId = facilityRowVersionId;
            Form = form;
        }

        public Guid? FacilityId { get; }

        public Guid? FacilityRowVersionId { get; }

        public WorkspaceFacilityUpdateFormModel? Form { get; }
    }
}
