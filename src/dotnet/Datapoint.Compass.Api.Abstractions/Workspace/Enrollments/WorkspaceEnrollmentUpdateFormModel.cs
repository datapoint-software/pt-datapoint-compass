using System;

namespace Datapoint.Compass.Api.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateFormModel
    {
        public WorkspaceEnrollmentUpdateFormModel(Guid facilityId, Guid serviceId, DateTimeOffset? start)
        {
            FacilityId = facilityId;
            ServiceId = serviceId;
            Start = start;
        }

        public Guid FacilityId { get; }

        public Guid ServiceId { get; }

        public DateTimeOffset? Start { get; }
    }
}