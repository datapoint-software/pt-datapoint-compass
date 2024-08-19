using System;
using System.Collections.Generic;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Update
{
    public sealed class WorkspaceEnrollmentUpdateComponentFormModel
    {
        public WorkspaceEnrollmentUpdateComponentFormModel(Guid? serviceId, Guid? facilityId, IEnumerable<Guid>? facilityIds, DateTimeOffset? start, string? comments)
        {
            ServiceId = serviceId;
            FacilityId = facilityId;
            FacilityIds = facilityIds;
            Start = start;
            Comments = comments;
        }

        public Guid? ServiceId { get; }

        public Guid? FacilityId { get; }

        public IEnumerable<Guid>? FacilityIds { get; }

        public DateTimeOffset? Start { get; }

        public string? Comments { get; }
    }
}
