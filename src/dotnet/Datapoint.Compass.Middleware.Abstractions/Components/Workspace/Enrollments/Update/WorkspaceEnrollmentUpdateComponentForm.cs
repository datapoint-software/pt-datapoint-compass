using System;

namespace Datapoint.Compass.Middleware.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentForm
    {
        public WorkspaceEnrollmentUpdateComponentForm(Guid? serviceId, Guid? facilityId, DateTimeOffset? start, string? comments)
        {
            ServiceId = serviceId;
            FacilityId = facilityId;
            Start = start;
            Comments = comments;
        }

        public Guid? ServiceId { get; }

        public Guid? FacilityId { get; }

        public DateTimeOffset? Start { get; }

        public string? Comments { get; }
    }
}
