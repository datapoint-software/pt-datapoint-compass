using Datapoint.Compass.Enumerations;
using System;

namespace Datapoint.Compass.Api.Components.Workspace.Enrollments.Search
{
    public sealed class WorkspaceEnrollmentSearchComponentSearchResultMatchModel
    {
        public WorkspaceEnrollmentSearchComponentSearchResultMatchModel(Guid id, Guid serviceId, Guid? facilityId, string number, EnrollmentStatus status, DateTimeOffset creation, DateTimeOffset? start)
        {
            Id = id;
            ServiceId = serviceId;
            FacilityId = facilityId;
            Number = number;
            Status = status;
            Creation = creation;
            Start = start;
        }

        public Guid Id { get; }

        public Guid ServiceId { get; }

        public Guid? FacilityId { get; }

        public string Number { get; }

        public EnrollmentStatus Status { get; }

        public DateTimeOffset Creation { get; }

        public DateTimeOffset? Start { get; }
    }
}
