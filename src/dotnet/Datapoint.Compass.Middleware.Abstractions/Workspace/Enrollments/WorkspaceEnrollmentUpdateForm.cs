using System;

namespace Datapoint.Compass.Middleware.Workspace.Enrollments
{
    public sealed class WorkspaceEnrollmentUpdateForm
    {
        public WorkspaceEnrollmentUpdateForm(Guid facilityId, Guid serviceId, DateTimeOffset? start)
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